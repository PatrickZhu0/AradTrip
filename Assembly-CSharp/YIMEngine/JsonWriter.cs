using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace YIMEngine
{
	// Token: 0x02004A88 RID: 19080
	public class JsonWriter
	{
		// Token: 0x0601BABC RID: 113340 RVA: 0x0087ECD8 File Offset: 0x0087D0D8
		public JsonWriter()
		{
			this.inst_string_builder = new StringBuilder();
			this.writer = new StringWriter(this.inst_string_builder);
			this.Init();
		}

		// Token: 0x0601BABD RID: 113341 RVA: 0x0087ED02 File Offset: 0x0087D102
		public JsonWriter(StringBuilder sb) : this(new StringWriter(sb))
		{
		}

		// Token: 0x0601BABE RID: 113342 RVA: 0x0087ED10 File Offset: 0x0087D110
		public JsonWriter(TextWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			this.writer = writer;
			this.Init();
		}

		// Token: 0x17002531 RID: 9521
		// (get) Token: 0x0601BABF RID: 113343 RVA: 0x0087ED36 File Offset: 0x0087D136
		// (set) Token: 0x0601BAC0 RID: 113344 RVA: 0x0087ED3E File Offset: 0x0087D13E
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

		// Token: 0x17002532 RID: 9522
		// (get) Token: 0x0601BAC1 RID: 113345 RVA: 0x0087ED5C File Offset: 0x0087D15C
		// (set) Token: 0x0601BAC2 RID: 113346 RVA: 0x0087ED64 File Offset: 0x0087D164
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

		// Token: 0x17002533 RID: 9523
		// (get) Token: 0x0601BAC3 RID: 113347 RVA: 0x0087ED6D File Offset: 0x0087D16D
		public TextWriter TextWriter
		{
			get
			{
				return this.writer;
			}
		}

		// Token: 0x17002534 RID: 9524
		// (get) Token: 0x0601BAC4 RID: 113348 RVA: 0x0087ED75 File Offset: 0x0087D175
		// (set) Token: 0x0601BAC5 RID: 113349 RVA: 0x0087ED7D File Offset: 0x0087D17D
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

		// Token: 0x0601BAC6 RID: 113350 RVA: 0x0087ED88 File Offset: 0x0087D188
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

		// Token: 0x0601BAC7 RID: 113351 RVA: 0x0087EEEC File Offset: 0x0087D2EC
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

		// Token: 0x0601BAC8 RID: 113352 RVA: 0x0087EF50 File Offset: 0x0087D350
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

		// Token: 0x0601BAC9 RID: 113353 RVA: 0x0087EF9D File Offset: 0x0087D39D
		private void Indent()
		{
			if (this.pretty_print)
			{
				this.indentation += this.indent_value;
			}
		}

		// Token: 0x0601BACA RID: 113354 RVA: 0x0087EFC0 File Offset: 0x0087D3C0
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

		// Token: 0x0601BACB RID: 113355 RVA: 0x0087F018 File Offset: 0x0087D418
		private void PutNewline()
		{
			this.PutNewline(true);
		}

		// Token: 0x0601BACC RID: 113356 RVA: 0x0087F024 File Offset: 0x0087D424
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

		// Token: 0x0601BACD RID: 113357 RVA: 0x0087F090 File Offset: 0x0087D490
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

		// Token: 0x0601BACE RID: 113358 RVA: 0x0087F20B File Offset: 0x0087D60B
		private void Unindent()
		{
			if (this.pretty_print)
			{
				this.indentation -= this.indent_value;
			}
		}

		// Token: 0x0601BACF RID: 113359 RVA: 0x0087F22B File Offset: 0x0087D62B
		public override string ToString()
		{
			if (this.inst_string_builder == null)
			{
				return string.Empty;
			}
			return this.inst_string_builder.ToString();
		}

		// Token: 0x0601BAD0 RID: 113360 RVA: 0x0087F24C File Offset: 0x0087D64C
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

		// Token: 0x0601BAD1 RID: 113361 RVA: 0x0087F2AA File Offset: 0x0087D6AA
		public void Write(bool boolean)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put((!boolean) ? "false" : "true");
			this.context.ExpectingValue = false;
		}

		// Token: 0x0601BAD2 RID: 113362 RVA: 0x0087F2E0 File Offset: 0x0087D6E0
		public void Write(decimal number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x0601BAD3 RID: 113363 RVA: 0x0087F30C File Offset: 0x0087D70C
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

		// Token: 0x0601BAD4 RID: 113364 RVA: 0x0087F371 File Offset: 0x0087D771
		public void Write(int number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x0601BAD5 RID: 113365 RVA: 0x0087F39D File Offset: 0x0087D79D
		public void Write(long number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x0601BAD6 RID: 113366 RVA: 0x0087F3C9 File Offset: 0x0087D7C9
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

		// Token: 0x0601BAD7 RID: 113367 RVA: 0x0087F401 File Offset: 0x0087D801
		[CLSCompliant(false)]
		public void Write(ulong number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x0601BAD8 RID: 113368 RVA: 0x0087F430 File Offset: 0x0087D830
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

		// Token: 0x0601BAD9 RID: 113369 RVA: 0x0087F4A4 File Offset: 0x0087D8A4
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

		// Token: 0x0601BADA RID: 113370 RVA: 0x0087F4F8 File Offset: 0x0087D8F8
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

		// Token: 0x0601BADB RID: 113371 RVA: 0x0087F56C File Offset: 0x0087D96C
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

		// Token: 0x0601BADC RID: 113372 RVA: 0x0087F5C0 File Offset: 0x0087D9C0
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

		// Token: 0x04013478 RID: 78968
		private static NumberFormatInfo number_format = NumberFormatInfo.InvariantInfo;

		// Token: 0x04013479 RID: 78969
		private WriterContext context;

		// Token: 0x0401347A RID: 78970
		private Stack<WriterContext> ctx_stack;

		// Token: 0x0401347B RID: 78971
		private bool has_reached_end;

		// Token: 0x0401347C RID: 78972
		private char[] hex_seq;

		// Token: 0x0401347D RID: 78973
		private int indentation;

		// Token: 0x0401347E RID: 78974
		private int indent_value;

		// Token: 0x0401347F RID: 78975
		private StringBuilder inst_string_builder;

		// Token: 0x04013480 RID: 78976
		private bool pretty_print;

		// Token: 0x04013481 RID: 78977
		private bool validate;

		// Token: 0x04013482 RID: 78978
		private TextWriter writer;
	}
}
