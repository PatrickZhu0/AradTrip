using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace LitJson
{
	// Token: 0x020046AB RID: 18091
	public class JsonWriter
	{
		// Token: 0x060199E9 RID: 104937 RVA: 0x00810FC0 File Offset: 0x0080F3C0
		public JsonWriter()
		{
			this.inst_string_builder = new StringBuilder();
			this.writer = new StringWriter(this.inst_string_builder);
			this.Init();
		}

		// Token: 0x060199EA RID: 104938 RVA: 0x00810FEA File Offset: 0x0080F3EA
		public JsonWriter(StringBuilder sb) : this(new StringWriter(sb))
		{
		}

		// Token: 0x060199EB RID: 104939 RVA: 0x00810FF8 File Offset: 0x0080F3F8
		public JsonWriter(TextWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			this.writer = writer;
			this.Init();
		}

		// Token: 0x17002127 RID: 8487
		// (get) Token: 0x060199EC RID: 104940 RVA: 0x0081101E File Offset: 0x0080F41E
		// (set) Token: 0x060199ED RID: 104941 RVA: 0x00811026 File Offset: 0x0080F426
		public int IndentValue
		{
			get
			{
				return this.indent_value;
			}
			set
			{
				this.indentation = this.indentation / this.indent_value * value;
				this.indent_value = value;
			}
		}

		// Token: 0x17002128 RID: 8488
		// (get) Token: 0x060199EE RID: 104942 RVA: 0x00811044 File Offset: 0x0080F444
		// (set) Token: 0x060199EF RID: 104943 RVA: 0x0081104C File Offset: 0x0080F44C
		public bool PrettyPrint
		{
			get
			{
				return this.pretty_print;
			}
			set
			{
				this.pretty_print = value;
			}
		}

		// Token: 0x17002129 RID: 8489
		// (get) Token: 0x060199F0 RID: 104944 RVA: 0x00811055 File Offset: 0x0080F455
		public TextWriter TextWriter
		{
			get
			{
				return this.writer;
			}
		}

		// Token: 0x1700212A RID: 8490
		// (get) Token: 0x060199F1 RID: 104945 RVA: 0x0081105D File Offset: 0x0080F45D
		// (set) Token: 0x060199F2 RID: 104946 RVA: 0x00811065 File Offset: 0x0080F465
		public bool Validate
		{
			get
			{
				return this.validate;
			}
			set
			{
				this.validate = value;
			}
		}

		// Token: 0x060199F3 RID: 104947 RVA: 0x00811070 File Offset: 0x0080F470
		private void DoValidation(Condition cond)
		{
			if (!this.context.ExpectingValue)
			{
				this.context.Count++;
			}
			if (!this.validate)
			{
				return;
			}
			if (this.has_reached_end)
			{
				throw new JsonException("A complete JSON symbol has already been written");
			}
			switch (cond)
			{
			case Condition.InArray:
				if (!this.context.InArray)
				{
					throw new JsonException("Can't close an array here");
				}
				break;
			case Condition.InObject:
				if (!this.context.InObject || this.context.ExpectingValue)
				{
					throw new JsonException("Can't close an object here");
				}
				break;
			case Condition.NotAProperty:
				if (this.context.InObject && !this.context.ExpectingValue)
				{
					throw new JsonException("Expected a property");
				}
				break;
			case Condition.Property:
				if (!this.context.InObject || this.context.ExpectingValue)
				{
					throw new JsonException("Can't add a property here");
				}
				break;
			case Condition.Value:
				if (!this.context.InArray && (!this.context.InObject || !this.context.ExpectingValue))
				{
					throw new JsonException("Can't add a value here");
				}
				break;
			}
		}

		// Token: 0x060199F4 RID: 104948 RVA: 0x008111D4 File Offset: 0x0080F5D4
		private void Init()
		{
			this.has_reached_end = false;
			this.hex_seq = new char[4];
			this.indentation = 0;
			this.indent_value = 4;
			this.pretty_print = false;
			this.validate = true;
			this.ctx_stack = new Stack<WriterContext>();
			this.context = new WriterContext();
			this.ctx_stack.Push(this.context);
		}

		// Token: 0x060199F5 RID: 104949 RVA: 0x00811238 File Offset: 0x0080F638
		private static void IntToHex(int n, char[] hex)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = n % 16;
				if (num < 10)
				{
					hex[3 - i] = (char)(48 + num);
				}
				else
				{
					hex[3 - i] = (char)(65 + (num - 10));
				}
				n >>= 4;
			}
		}

		// Token: 0x060199F6 RID: 104950 RVA: 0x00811285 File Offset: 0x0080F685
		private void Indent()
		{
			if (this.pretty_print)
			{
				this.indentation += this.indent_value;
			}
		}

		// Token: 0x060199F7 RID: 104951 RVA: 0x008112A8 File Offset: 0x0080F6A8
		private void Put(string str)
		{
			if (this.pretty_print && !this.context.ExpectingValue)
			{
				for (int i = 0; i < this.indentation; i++)
				{
					this.writer.Write(' ');
				}
			}
			this.writer.Write(str);
		}

		// Token: 0x060199F8 RID: 104952 RVA: 0x00811300 File Offset: 0x0080F700
		private void PutNewline()
		{
			this.PutNewline(true);
		}

		// Token: 0x060199F9 RID: 104953 RVA: 0x0081130C File Offset: 0x0080F70C
		private void PutNewline(bool add_comma)
		{
			if (add_comma && !this.context.ExpectingValue && this.context.Count > 1)
			{
				this.writer.Write(',');
			}
			if (this.pretty_print && !this.context.ExpectingValue)
			{
				this.writer.Write('\n');
			}
		}

		// Token: 0x060199FA RID: 104954 RVA: 0x00811378 File Offset: 0x0080F778
		private void PutString(string str)
		{
			this.Put(string.Empty);
			this.writer.Write('"');
			int length = str.Length;
			for (int i = 0; i < length; i++)
			{
				char c = str[i];
				switch (c)
				{
				case '\b':
					this.writer.Write("\\b");
					break;
				case '\t':
					this.writer.Write("\\t");
					break;
				case '\n':
					this.writer.Write("\\n");
					break;
				default:
					if (c != '"' && c != '\\')
					{
						if (str[i] >= ' ' && str[i] <= '~')
						{
							this.writer.Write(str[i]);
						}
						else
						{
							JsonWriter.IntToHex((int)str[i], this.hex_seq);
							this.writer.Write("\\u");
							this.writer.Write(this.hex_seq);
						}
					}
					else
					{
						this.writer.Write('\\');
						this.writer.Write(str[i]);
					}
					break;
				case '\f':
					this.writer.Write("\\f");
					break;
				case '\r':
					this.writer.Write("\\r");
					break;
				}
			}
			this.writer.Write('"');
		}

		// Token: 0x060199FB RID: 104955 RVA: 0x008114F3 File Offset: 0x0080F8F3
		private void Unindent()
		{
			if (this.pretty_print)
			{
				this.indentation -= this.indent_value;
			}
		}

		// Token: 0x060199FC RID: 104956 RVA: 0x00811513 File Offset: 0x0080F913
		public override string ToString()
		{
			if (this.inst_string_builder == null)
			{
				return string.Empty;
			}
			return this.inst_string_builder.ToString();
		}

		// Token: 0x060199FD RID: 104957 RVA: 0x00811534 File Offset: 0x0080F934
		public void Reset()
		{
			this.has_reached_end = false;
			this.ctx_stack.Clear();
			this.context = new WriterContext();
			this.ctx_stack.Push(this.context);
			if (this.inst_string_builder != null)
			{
				this.inst_string_builder.Remove(0, this.inst_string_builder.Length);
			}
		}

		// Token: 0x060199FE RID: 104958 RVA: 0x00811592 File Offset: 0x0080F992
		public void Write(bool boolean)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put((!boolean) ? "false" : "true");
			this.context.ExpectingValue = false;
		}

		// Token: 0x060199FF RID: 104959 RVA: 0x008115C8 File Offset: 0x0080F9C8
		public void Write(decimal number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x06019A00 RID: 104960 RVA: 0x008115F4 File Offset: 0x0080F9F4
		public void Write(double number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			string text = Convert.ToString(number, JsonWriter.number_format);
			this.Put(text);
			if (text.IndexOf('.') == -1 && text.IndexOf('E') == -1)
			{
				this.writer.Write(".0");
			}
			this.context.ExpectingValue = false;
		}

		// Token: 0x06019A01 RID: 104961 RVA: 0x00811659 File Offset: 0x0080FA59
		public void Write(int number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x06019A02 RID: 104962 RVA: 0x00811685 File Offset: 0x0080FA85
		public void Write(long number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x06019A03 RID: 104963 RVA: 0x008116B1 File Offset: 0x0080FAB1
		public void Write(string str)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			if (str == null)
			{
				this.Put("null");
			}
			else
			{
				this.PutString(str);
			}
			this.context.ExpectingValue = false;
		}

		// Token: 0x06019A04 RID: 104964 RVA: 0x008116E9 File Offset: 0x0080FAE9
		[CLSCompliant(false)]
		public void Write(ulong number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x06019A05 RID: 104965 RVA: 0x00811718 File Offset: 0x0080FB18
		public void WriteArrayEnd()
		{
			this.DoValidation(Condition.InArray);
			this.PutNewline(false);
			this.ctx_stack.Pop();
			if (this.ctx_stack.Count == 1)
			{
				this.has_reached_end = true;
			}
			else
			{
				this.context = this.ctx_stack.Peek();
				this.context.ExpectingValue = false;
			}
			this.Unindent();
			this.Put("]");
		}

		// Token: 0x06019A06 RID: 104966 RVA: 0x0081178C File Offset: 0x0080FB8C
		public void WriteArrayStart()
		{
			this.DoValidation(Condition.NotAProperty);
			this.PutNewline();
			this.Put("[");
			this.context = new WriterContext();
			this.context.InArray = true;
			this.ctx_stack.Push(this.context);
			this.Indent();
		}

		// Token: 0x06019A07 RID: 104967 RVA: 0x008117E0 File Offset: 0x0080FBE0
		public void WriteObjectEnd()
		{
			this.DoValidation(Condition.InObject);
			this.PutNewline(false);
			this.ctx_stack.Pop();
			if (this.ctx_stack.Count == 1)
			{
				this.has_reached_end = true;
			}
			else
			{
				this.context = this.ctx_stack.Peek();
				this.context.ExpectingValue = false;
			}
			this.Unindent();
			this.Put("}");
		}

		// Token: 0x06019A08 RID: 104968 RVA: 0x00811854 File Offset: 0x0080FC54
		public void WriteObjectStart()
		{
			this.DoValidation(Condition.NotAProperty);
			this.PutNewline();
			this.Put("{");
			this.context = new WriterContext();
			this.context.InObject = true;
			this.ctx_stack.Push(this.context);
			this.Indent();
		}

		// Token: 0x06019A09 RID: 104969 RVA: 0x008118A8 File Offset: 0x0080FCA8
		public void WritePropertyName(string property_name)
		{
			this.DoValidation(Condition.Property);
			this.PutNewline();
			this.PutString(property_name);
			if (this.pretty_print)
			{
				if (property_name.Length > this.context.Padding)
				{
					this.context.Padding = property_name.Length;
				}
				for (int i = this.context.Padding - property_name.Length; i >= 0; i--)
				{
					this.writer.Write(' ');
				}
				this.writer.Write(": ");
			}
			else
			{
				this.writer.Write(':');
			}
			this.context.ExpectingValue = true;
		}

		// Token: 0x04012412 RID: 74770
		private static NumberFormatInfo number_format = NumberFormatInfo.InvariantInfo;

		// Token: 0x04012413 RID: 74771
		private WriterContext context;

		// Token: 0x04012414 RID: 74772
		private Stack<WriterContext> ctx_stack;

		// Token: 0x04012415 RID: 74773
		private bool has_reached_end;

		// Token: 0x04012416 RID: 74774
		private char[] hex_seq;

		// Token: 0x04012417 RID: 74775
		private int indentation;

		// Token: 0x04012418 RID: 74776
		private int indent_value;

		// Token: 0x04012419 RID: 74777
		private StringBuilder inst_string_builder;

		// Token: 0x0401241A RID: 74778
		private bool pretty_print;

		// Token: 0x0401241B RID: 74779
		private bool validate;

		// Token: 0x0401241C RID: 74780
		private TextWriter writer;
	}
}
