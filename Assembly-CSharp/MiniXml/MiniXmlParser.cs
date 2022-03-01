using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;

namespace MiniXml
{
	// Token: 0x02004803 RID: 18435
	internal class MiniXmlParser
	{
		// Token: 0x0601A7BB RID: 108475 RVA: 0x008336E8 File Offset: 0x00831AE8
		private static bool IsUnicodeSep(char c, bool start)
		{
			switch (char.GetUnicodeCategory(c))
			{
			case UnicodeCategory.UppercaseLetter:
			case UnicodeCategory.LowercaseLetter:
			case UnicodeCategory.TitlecaseLetter:
			case UnicodeCategory.OtherLetter:
			case UnicodeCategory.LetterNumber:
				return true;
			case UnicodeCategory.ModifierLetter:
			case UnicodeCategory.NonSpacingMark:
			case UnicodeCategory.SpacingCombiningMark:
			case UnicodeCategory.EnclosingMark:
			case UnicodeCategory.DecimalDigitNumber:
				return !start;
			default:
				return false;
			}
		}

		// Token: 0x0601A7BC RID: 108476 RVA: 0x00833737 File Offset: 0x00831B37
		private Exception ErrorMsg_(string msg)
		{
			return new MiniXmlParserException(msg, this.line, this.column);
		}

		// Token: 0x0601A7BD RID: 108477 RVA: 0x0083374C File Offset: 0x00831B4C
		private Exception UnexpectedEndException_()
		{
			string[] array = new string[this.elementNames_.Count];
			((ICollection)this.elementNames_).CopyTo(array, 0);
			return this.ErrorMsg_(string.Format("Unexpected end of stream. Element stack content is {0}", string.Join(",", array)));
		}

		// Token: 0x0601A7BE RID: 108478 RVA: 0x00833794 File Offset: 0x00831B94
		private bool IsNameChararcter_(char c, bool start)
		{
			if (c == '-' || c == '.')
			{
				return !start;
			}
			if (c != ':' && c != '_')
			{
				if (c > 'Ā')
				{
					if (c == 'ՙ' || c == 'ۥ' || c == 'ۦ')
					{
						return true;
					}
					if ('ʻ' <= c && c <= 'ˁ')
					{
						return true;
					}
				}
				return MiniXmlParser.IsUnicodeSep(c, start);
			}
			return true;
		}

		// Token: 0x0601A7BF RID: 108479 RVA: 0x0083381F File Offset: 0x00831C1F
		private bool IsBlank_(int c)
		{
			switch (c)
			{
			case 9:
			case 10:
			case 13:
				break;
			default:
				if (c != 32)
				{
					return false;
				}
				break;
			}
			return true;
		}

		// Token: 0x0601A7C0 RID: 108480 RVA: 0x0083384E File Offset: 0x00831C4E
		public void SkipBlank()
		{
			this.SkipBlanks_(false);
		}

		// Token: 0x0601A7C1 RID: 108481 RVA: 0x00833858 File Offset: 0x00831C58
		public void SkipBlanks_(bool expected)
		{
			for (;;)
			{
				int num = this.PeekNext_();
				switch (num)
				{
				case 9:
				case 10:
				case 13:
					break;
				default:
					if (num != 32)
					{
						goto Block_0;
					}
					break;
				}
				this.ReadNext_();
				if (expected)
				{
					expected = false;
				}
			}
			Block_0:
			if (expected)
			{
				throw this.ErrorMsg_("Whitespace is expected.");
			}
		}

		// Token: 0x0601A7C2 RID: 108482 RVA: 0x008338C4 File Offset: 0x00831CC4
		private void HandleBlank_()
		{
			while (this.IsBlank_(this.PeekNext_()))
			{
				this.stringBuffer_.Append((char)this.ReadNext_());
			}
			if (this.PeekNext_() != 60 && this.PeekNext_() >= 0)
			{
				this.isBlank_ = false;
			}
		}

		// Token: 0x0601A7C3 RID: 108483 RVA: 0x0083391C File Offset: 0x00831D1C
		private int ReadNext_()
		{
			int num = this.textReader_.Read();
			if (num == 10)
			{
				this.resetCol_ = true;
			}
			if (this.resetCol_)
			{
				this.line++;
				this.resetCol_ = false;
				this.column = 1;
			}
			else
			{
				this.column++;
			}
			return num;
		}

		// Token: 0x0601A7C4 RID: 108484 RVA: 0x0083397F File Offset: 0x00831D7F
		private int PeekNext_()
		{
			return this.textReader_.Peek();
		}

		// Token: 0x0601A7C5 RID: 108485 RVA: 0x0083398C File Offset: 0x00831D8C
		public void Expect(int c)
		{
			int num = this.ReadNext_();
			if (num < 0)
			{
				throw this.UnexpectedEndException_();
			}
			if (num != c)
			{
				throw this.ErrorMsg_(string.Format("Expected '{0}' but got {1}", (char)c, (char)num));
			}
		}

		// Token: 0x0601A7C6 RID: 108486 RVA: 0x008339D4 File Offset: 0x00831DD4
		public string ReadName()
		{
			int num = 0;
			if (this.PeekNext_() < 0 || !this.IsNameChararcter_((char)this.PeekNext_(), true))
			{
				throw this.ErrorMsg_("XML name start character is expected.");
			}
			for (int i = this.PeekNext_(); i >= 0; i = this.PeekNext_())
			{
				char c = (char)i;
				if (!this.IsNameChararcter_(c, false))
				{
					break;
				}
				if (num == this.nameBufferArray_.Length)
				{
					char[] destinationArray = new char[num * 2];
					Array.Copy(this.nameBufferArray_, 0, destinationArray, 0, num);
					this.nameBufferArray_ = destinationArray;
				}
				this.nameBufferArray_[num++] = c;
				this.ReadNext_();
			}
			if (num == 0)
			{
				throw this.ErrorMsg_("Valid XML name is expected.");
			}
			return new string(this.nameBufferArray_, 0, num);
		}

		// Token: 0x0601A7C7 RID: 108487 RVA: 0x00833AA0 File Offset: 0x00831EA0
		public void Parse(TextReader input, MiniXmlParser.IXmlHandler handler)
		{
			this.textReader_ = input;
			this.xmlHandler_ = handler;
			handler.OnStartParsing(this);
			while (this.PeekNext_() >= 0)
			{
				this.ReadAll();
			}
			this.HandleBufferContent_();
			if (this.elementNames_.Count > 0)
			{
				throw this.ErrorMsg_(string.Format("Insufficient close tag: {0}", this.elementNames_.Peek()));
			}
			handler.OnEndParsing(this);
			this.Cleanup();
		}

		// Token: 0x0601A7C8 RID: 108488 RVA: 0x00833B1C File Offset: 0x00831F1C
		private string ReadUntil_(char until, bool handleReferences)
		{
			while (this.PeekNext_() >= 0)
			{
				char c = (char)this.ReadNext_();
				if (c == until)
				{
					string result = this.stringBuffer_.ToString();
					this.stringBuffer_.Length = 0;
					return result;
				}
				if (handleReferences && c == '&')
				{
					this.ReadRef_();
				}
				else
				{
					this.stringBuffer_.Append(c);
				}
			}
			throw this.UnexpectedEndException_();
		}

		// Token: 0x0601A7C9 RID: 108489 RVA: 0x00833B94 File Offset: 0x00831F94
		private void Cleanup()
		{
			this.line = 1;
			this.column = 0;
			this.xmlHandler_ = null;
			this.textReader_ = null;
			this.elementNames_.Clear();
			this.xmlSpaces_.Clear();
			this._attributes.Clear();
			this.stringBuffer_.Length = 0;
			this.xmlBlank_ = null;
			this.isBlank_ = false;
		}

		// Token: 0x0601A7CA RID: 108490 RVA: 0x00833BF8 File Offset: 0x00831FF8
		public void ReadAll()
		{
			if (this.IsBlank_(this.PeekNext_()))
			{
				if (this.stringBuffer_.Length == 0)
				{
					this.isBlank_ = true;
				}
				this.HandleBlank_();
			}
			if (this.PeekNext_() != 60)
			{
				this.ReadChars_();
				return;
			}
			this.ReadNext_();
			int num = this.PeekNext_();
			if (num != 33)
			{
				if (num != 47)
				{
					string text;
					if (num != 63)
					{
						this.HandleBufferContent_();
						text = this.ReadName();
						while (this.PeekNext_() != 62 && this.PeekNext_() != 47)
						{
							this.ReadAttr_(this._attributes);
						}
						this.xmlHandler_.OnStart(text, this._attributes);
						this._attributes.Clear();
						this.SkipBlank();
						if (this.PeekNext_() == 47)
						{
							this.ReadNext_();
							this.xmlHandler_.OnEnd(text);
						}
						else
						{
							this.elementNames_.Push(text);
							this.xmlSpaces_.Push(this.xmlBlank_);
						}
						this.Expect(62);
						return;
					}
					this.HandleBufferContent_();
					this.ReadNext_();
					text = this.ReadName();
					this.SkipBlank();
					string text2 = string.Empty;
					if (this.PeekNext_() != 63)
					{
						for (;;)
						{
							text2 += this.ReadUntil_('?', false);
							if (this.PeekNext_() == 62)
							{
								break;
							}
							text2 += "?";
						}
					}
					this.xmlHandler_.OnProcess(text, text2);
					this.Expect(62);
					return;
				}
				else
				{
					this.HandleBufferContent_();
					if (this.elementNames_.Count == 0)
					{
						throw this.UnexpectedEndException_();
					}
					this.ReadNext_();
					string text = this.ReadName();
					this.SkipBlank();
					string text3 = (string)this.elementNames_.Pop();
					this.xmlSpaces_.Pop();
					if (this.xmlSpaces_.Count > 0)
					{
						this.xmlBlank_ = (string)this.xmlSpaces_.Peek();
					}
					else
					{
						this.xmlBlank_ = null;
					}
					if (text != text3)
					{
						throw this.ErrorMsg_(string.Format("End tag mismatch: expected {0} but found {1}", text3, text));
					}
					this.xmlHandler_.OnEnd(text);
					this.Expect(62);
					return;
				}
			}
			else
			{
				this.ReadNext_();
				if (this.PeekNext_() == 91)
				{
					this.ReadNext_();
					if (this.ReadName() != "CDATA")
					{
						throw this.ErrorMsg_("Invalid declaration markup");
					}
					this.Expect(91);
					this.ReadCDATA_();
					return;
				}
				else
				{
					if (this.PeekNext_() == 45)
					{
						this.ReadComment_();
						return;
					}
					if (this.ReadName() != "DOCTYPE")
					{
						throw this.ErrorMsg_("Invalid declaration markup.");
					}
					throw this.ErrorMsg_("This parser does not support document type.");
				}
			}
		}

		// Token: 0x0601A7CB RID: 108491 RVA: 0x00833ED0 File Offset: 0x008322D0
		private void ReadChars_()
		{
			this.isBlank_ = false;
			for (;;)
			{
				int num = this.PeekNext_();
				if (num == -1)
				{
					break;
				}
				if (num != 38)
				{
					if (num == 60)
					{
						return;
					}
					this.stringBuffer_.Append((char)this.ReadNext_());
				}
				else
				{
					this.ReadNext_();
					this.ReadRef_();
				}
			}
		}

		// Token: 0x0601A7CC RID: 108492 RVA: 0x00833F38 File Offset: 0x00832338
		private void ReadRef_()
		{
			if (this.PeekNext_() != 35)
			{
				string text = this.ReadName();
				this.Expect(59);
				if (text != null)
				{
					if (text == "amp")
					{
						this.stringBuffer_.Append('&');
						return;
					}
					if (text == "quot")
					{
						this.stringBuffer_.Append('"');
						return;
					}
					if (text == "apos")
					{
						this.stringBuffer_.Append('\'');
						return;
					}
					if (text == "lt")
					{
						this.stringBuffer_.Append('<');
						return;
					}
					if (text == "gt")
					{
						this.stringBuffer_.Append('>');
						return;
					}
				}
				throw this.ErrorMsg_("General non-predefined entity reference is not supported in this parser.");
			}
			this.ReadNext_();
			this.ReadCharRef_();
		}

		// Token: 0x0601A7CD RID: 108493 RVA: 0x0083403C File Offset: 0x0083243C
		private void HandleBufferContent_()
		{
			if (this.stringBuffer_.Length == 0)
			{
				return;
			}
			if (this.isBlank_)
			{
				this.xmlHandler_.OnIgnorableSpaces(this.stringBuffer_.ToString());
			}
			else
			{
				this.xmlHandler_.OnChars(this.stringBuffer_.ToString());
			}
			this.stringBuffer_.Length = 0;
			this.isBlank_ = false;
		}

		// Token: 0x0601A7CE RID: 108494 RVA: 0x008340AC File Offset: 0x008324AC
		private int ReadCharRef_()
		{
			int num = 0;
			if (this.PeekNext_() == 120)
			{
				this.ReadNext_();
				for (int i = this.PeekNext_(); i >= 0; i = this.PeekNext_())
				{
					if (48 <= i && i <= 57)
					{
						num <<= 4 + i - 48;
					}
					else if (65 <= i && i <= 70)
					{
						num <<= 4 + i - 65 + 10;
					}
					else
					{
						if (97 > i || i > 102)
						{
							break;
						}
						num <<= 4 + i - 97 + 10;
					}
					this.ReadNext_();
				}
			}
			else
			{
				for (int j = this.PeekNext_(); j >= 0; j = this.PeekNext_())
				{
					if (48 > j || j > 57)
					{
						break;
					}
					num <<= 4 + j - 48;
					this.ReadNext_();
				}
			}
			return num;
		}

		// Token: 0x0601A7CF RID: 108495 RVA: 0x008341AC File Offset: 0x008325AC
		private void ReadAttr_(MiniXmlParser.AttributeListImpl a)
		{
			this.SkipBlanks_(true);
			if (this.PeekNext_() == 47 || this.PeekNext_() == 62)
			{
				return;
			}
			string text = this.ReadName();
			this.SkipBlank();
			this.Expect(61);
			this.SkipBlank();
			int num = this.ReadNext_();
			string value;
			if (num != 39)
			{
				if (num != 34)
				{
					throw this.ErrorMsg_("Invalid attribute value markup.");
				}
				value = this.ReadUntil_('"', true);
			}
			else
			{
				value = this.ReadUntil_('\'', true);
			}
			if (text == "xml:space")
			{
				this.xmlBlank_ = value;
			}
			a.Add(text, value);
		}

		// Token: 0x0601A7D0 RID: 108496 RVA: 0x0083425C File Offset: 0x0083265C
		private void ReadComment_()
		{
			this.Expect(45);
			this.Expect(45);
			for (;;)
			{
				if (this.ReadNext_() == 45)
				{
					if (this.ReadNext_() == 45)
					{
						break;
					}
				}
			}
			if (this.ReadNext_() != 62)
			{
				throw this.ErrorMsg_("'--' is not allowed inside comment markup.");
			}
		}

		// Token: 0x0601A7D1 RID: 108497 RVA: 0x008342C0 File Offset: 0x008326C0
		private void ReadCDATA_()
		{
			int num = 0;
			while (this.PeekNext_() >= 0)
			{
				char c = (char)this.ReadNext_();
				if (c == ']')
				{
					num++;
				}
				else
				{
					if (c == '>' && num > 1)
					{
						for (int i = num; i > 2; i--)
						{
							this.stringBuffer_.Append(']');
						}
						return;
					}
					for (int j = 0; j < num; j++)
					{
						this.stringBuffer_.Append(']');
					}
					num = 0;
					this.stringBuffer_.Append(c);
				}
			}
			throw this.UnexpectedEndException_();
		}

		// Token: 0x04012915 RID: 76053
		private MiniXmlParser.IXmlHandler xmlHandler_;

		// Token: 0x04012916 RID: 76054
		private TextReader textReader_;

		// Token: 0x04012917 RID: 76055
		private Stack elementNames_ = new Stack();

		// Token: 0x04012918 RID: 76056
		private Stack xmlSpaces_ = new Stack();

		// Token: 0x04012919 RID: 76057
		private string xmlBlank_;

		// Token: 0x0401291A RID: 76058
		private StringBuilder stringBuffer_ = new StringBuilder(200);

		// Token: 0x0401291B RID: 76059
		private char[] nameBufferArray_ = new char[30];

		// Token: 0x0401291C RID: 76060
		private bool isBlank_;

		// Token: 0x0401291D RID: 76061
		private MiniXmlParser.AttributeListImpl _attributes = new MiniXmlParser.AttributeListImpl();

		// Token: 0x0401291E RID: 76062
		private int line = 1;

		// Token: 0x0401291F RID: 76063
		private int column;

		// Token: 0x04012920 RID: 76064
		private bool resetCol_;

		// Token: 0x02004804 RID: 18436
		public interface IXmlHandler
		{
			// Token: 0x0601A7D2 RID: 108498
			void OnStartParsing(MiniXmlParser parser);

			// Token: 0x0601A7D3 RID: 108499
			void OnEndParsing(MiniXmlParser parser);

			// Token: 0x0601A7D4 RID: 108500
			void OnStart(string szName, MiniXmlParser.IAttributeList attrsList);

			// Token: 0x0601A7D5 RID: 108501
			void OnEnd(string szName);

			// Token: 0x0601A7D6 RID: 108502
			void OnProcess(string szName, string content);

			// Token: 0x0601A7D7 RID: 108503
			void OnChars(string content);

			// Token: 0x0601A7D8 RID: 108504
			void OnIgnorableSpaces(string content);
		}

		// Token: 0x02004805 RID: 18437
		public interface IAttributeList
		{
			// Token: 0x17002276 RID: 8822
			// (get) Token: 0x0601A7D9 RID: 108505
			int AttrLength { get; }

			// Token: 0x17002277 RID: 8823
			// (get) Token: 0x0601A7DA RID: 108506
			bool IsEmpty { get; }

			// Token: 0x0601A7DB RID: 108507
			string GetAttrName(int i);

			// Token: 0x0601A7DC RID: 108508
			string GetAttrValue(int i);

			// Token: 0x0601A7DD RID: 108509
			string GetAttrValue(string name);

			// Token: 0x17002278 RID: 8824
			// (get) Token: 0x0601A7DE RID: 108510
			string[] Names { get; }

			// Token: 0x17002279 RID: 8825
			// (get) Token: 0x0601A7DF RID: 108511
			string[] Values { get; }
		}

		// Token: 0x02004806 RID: 18438
		private class AttributeListImpl : MiniXmlParser.IAttributeList
		{
			// Token: 0x1700227A RID: 8826
			// (get) Token: 0x0601A7E1 RID: 108513 RVA: 0x00834381 File Offset: 0x00832781
			public int AttrLength
			{
				get
				{
					return this.attrNames.Count;
				}
			}

			// Token: 0x1700227B RID: 8827
			// (get) Token: 0x0601A7E2 RID: 108514 RVA: 0x0083438E File Offset: 0x0083278E
			public bool IsEmpty
			{
				get
				{
					return this.attrNames.Count == 0;
				}
			}

			// Token: 0x0601A7E3 RID: 108515 RVA: 0x0083439E File Offset: 0x0083279E
			public string GetAttrName(int i)
			{
				return (string)this.attrNames[i];
			}

			// Token: 0x0601A7E4 RID: 108516 RVA: 0x008343B1 File Offset: 0x008327B1
			public string GetAttrValue(int i)
			{
				return (string)this.attrValues[i];
			}

			// Token: 0x0601A7E5 RID: 108517 RVA: 0x008343C4 File Offset: 0x008327C4
			public string GetAttrValue(string name)
			{
				for (int i = 0; i < this.attrNames.Count; i++)
				{
					if ((string)this.attrNames[i] == name)
					{
						return (string)this.attrValues[i];
					}
				}
				return null;
			}

			// Token: 0x1700227C RID: 8828
			// (get) Token: 0x0601A7E6 RID: 108518 RVA: 0x0083441C File Offset: 0x0083281C
			public string[] Names
			{
				get
				{
					return (string[])this.attrNames.ToArray(typeof(string));
				}
			}

			// Token: 0x1700227D RID: 8829
			// (get) Token: 0x0601A7E7 RID: 108519 RVA: 0x00834438 File Offset: 0x00832838
			public string[] Values
			{
				get
				{
					return (string[])this.attrValues.ToArray(typeof(string));
				}
			}

			// Token: 0x0601A7E8 RID: 108520 RVA: 0x00834454 File Offset: 0x00832854
			internal void Clear()
			{
				this.attrNames.Clear();
				this.attrValues.Clear();
			}

			// Token: 0x0601A7E9 RID: 108521 RVA: 0x0083446C File Offset: 0x0083286C
			internal void Add(string name, string value)
			{
				this.attrNames.Add(name);
				this.attrValues.Add(value);
			}

			// Token: 0x04012921 RID: 76065
			private ArrayList attrNames = new ArrayList();

			// Token: 0x04012922 RID: 76066
			private ArrayList attrValues = new ArrayList();
		}
	}
}
