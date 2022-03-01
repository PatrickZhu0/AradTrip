using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace YouMe
{
	// Token: 0x02004AD7 RID: 19159
	public class JsonWriter
	{
		// Token: 0x0601BD92 RID: 114066 RVA: 0x00886AD4 File Offset: 0x00884ED4
		public JsonWriter()
		{
			this.inst_string_builder = new StringBuilder();
			this.writer = new StringWriter(this.inst_string_builder);
			this.Init();
		}

		// Token: 0x0601BD93 RID: 114067 RVA: 0x00886AFE File Offset: 0x00884EFE
		public JsonWriter(StringBuilder sb) : this(new StringWriter(sb))
		{
		}

		// Token: 0x0601BD94 RID: 114068 RVA: 0x00886B0C File Offset: 0x00884F0C
		public JsonWriter(TextWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			this.writer = writer;
			this.Init();
		}

		// Token: 0x170025DD RID: 9693
		// (get) Token: 0x0601BD95 RID: 114069 RVA: 0x00886B32 File Offset: 0x00884F32
		// (set) Token: 0x0601BD96 RID: 114070 RVA: 0x00886B3A File Offset: 0x00884F3A
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

		// Token: 0x170025DE RID: 9694
		// (get) Token: 0x0601BD97 RID: 114071 RVA: 0x00886B58 File Offset: 0x00884F58
		// (set) Token: 0x0601BD98 RID: 114072 RVA: 0x00886B60 File Offset: 0x00884F60
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

		// Token: 0x170025DF RID: 9695
		// (get) Token: 0x0601BD99 RID: 114073 RVA: 0x00886B69 File Offset: 0x00884F69
		public TextWriter TextWriter
		{
			get
			{
				return this.writer;
			}
		}

		// Token: 0x170025E0 RID: 9696
		// (get) Token: 0x0601BD9A RID: 114074 RVA: 0x00886B71 File Offset: 0x00884F71
		// (set) Token: 0x0601BD9B RID: 114075 RVA: 0x00886B79 File Offset: 0x00884F79
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

		// Token: 0x0601BD9C RID: 114076 RVA: 0x00886B84 File Offset: 0x00884F84
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

		// Token: 0x0601BD9D RID: 114077 RVA: 0x00886CE8 File Offset: 0x008850E8
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

		// Token: 0x0601BD9E RID: 114078 RVA: 0x00886D4C File Offset: 0x0088514C
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

		// Token: 0x0601BD9F RID: 114079 RVA: 0x00886D99 File Offset: 0x00885199
		private void Indent()
		{
			if (this.pretty_print)
			{
				this.indentation += this.indent_value;
			}
		}

		// Token: 0x0601BDA0 RID: 114080 RVA: 0x00886DBC File Offset: 0x008851BC
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

		// Token: 0x0601BDA1 RID: 114081 RVA: 0x00886E14 File Offset: 0x00885214
		private void PutNewline()
		{
			this.PutNewline(true);
		}

		// Token: 0x0601BDA2 RID: 114082 RVA: 0x00886E20 File Offset: 0x00885220
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

		// Token: 0x0601BDA3 RID: 114083 RVA: 0x00886E8C File Offset: 0x0088528C
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

		// Token: 0x0601BDA4 RID: 114084 RVA: 0x00887007 File Offset: 0x00885407
		private void Unindent()
		{
			if (this.pretty_print)
			{
				this.indentation -= this.indent_value;
			}
		}

		// Token: 0x0601BDA5 RID: 114085 RVA: 0x00887027 File Offset: 0x00885427
		public override string ToString()
		{
			if (this.inst_string_builder == null)
			{
				return string.Empty;
			}
			return this.inst_string_builder.ToString();
		}

		// Token: 0x0601BDA6 RID: 114086 RVA: 0x00887048 File Offset: 0x00885448
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

		// Token: 0x0601BDA7 RID: 114087 RVA: 0x008870A6 File Offset: 0x008854A6
		public void Write(bool boolean)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put((!boolean) ? "false" : "true");
			this.context.ExpectingValue = false;
		}

		// Token: 0x0601BDA8 RID: 114088 RVA: 0x008870DC File Offset: 0x008854DC
		public void Write(decimal number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x0601BDA9 RID: 114089 RVA: 0x00887108 File Offset: 0x00885508
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

		// Token: 0x0601BDAA RID: 114090 RVA: 0x0088716D File Offset: 0x0088556D
		public void Write(int number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x0601BDAB RID: 114091 RVA: 0x00887199 File Offset: 0x00885599
		public void Write(long number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x0601BDAC RID: 114092 RVA: 0x008871C5 File Offset: 0x008855C5
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

		// Token: 0x0601BDAD RID: 114093 RVA: 0x008871FD File Offset: 0x008855FD
		[CLSCompliant(false)]
		public void Write(ulong number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x0601BDAE RID: 114094 RVA: 0x0088722C File Offset: 0x0088562C
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

		// Token: 0x0601BDAF RID: 114095 RVA: 0x008872A0 File Offset: 0x008856A0
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

		// Token: 0x0601BDB0 RID: 114096 RVA: 0x008872F4 File Offset: 0x008856F4
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

		// Token: 0x0601BDB1 RID: 114097 RVA: 0x00887368 File Offset: 0x00885768
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

		// Token: 0x0601BDB2 RID: 114098 RVA: 0x008873BC File Offset: 0x008857BC
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

		// Token: 0x0401363E RID: 79422
		private static NumberFormatInfo number_format = NumberFormatInfo.InvariantInfo;

		// Token: 0x0401363F RID: 79423
		private WriterContext context;

		// Token: 0x04013640 RID: 79424
		private Stack<WriterContext> ctx_stack;

		// Token: 0x04013641 RID: 79425
		private bool has_reached_end;

		// Token: 0x04013642 RID: 79426
		private char[] hex_seq;

		// Token: 0x04013643 RID: 79427
		private int indentation;

		// Token: 0x04013644 RID: 79428
		private int indent_value;

		// Token: 0x04013645 RID: 79429
		private StringBuilder inst_string_builder;

		// Token: 0x04013646 RID: 79430
		private bool pretty_print;

		// Token: 0x04013647 RID: 79431
		private bool validate;

		// Token: 0x04013648 RID: 79432
		private TextWriter writer;
	}
}
