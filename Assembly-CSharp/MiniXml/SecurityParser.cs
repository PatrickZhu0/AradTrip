using System;
using System.Collections;
using System.IO;
using System.Security;

namespace MiniXml
{
	// Token: 0x02004807 RID: 18439
	internal class SecurityParser : MiniXmlParser, MiniXmlParser.IXmlHandler
	{
		// Token: 0x0601A7EA RID: 108522 RVA: 0x00834488 File Offset: 0x00832888
		public SecurityParser()
		{
			this.stack = new Stack();
		}

		// Token: 0x0601A7EB RID: 108523 RVA: 0x0083449B File Offset: 0x0083289B
		public void LoadXml(string xml)
		{
			this.root = null;
			this.stack.Clear();
			base.Parse(new StringReader(xml), this);
		}

		// Token: 0x0601A7EC RID: 108524 RVA: 0x008344BC File Offset: 0x008328BC
		public SecurityElement ToXml()
		{
			return this.root;
		}

		// Token: 0x0601A7ED RID: 108525 RVA: 0x008344C4 File Offset: 0x008328C4
		public void OnStartParsing(MiniXmlParser parser)
		{
		}

		// Token: 0x0601A7EE RID: 108526 RVA: 0x008344C6 File Offset: 0x008328C6
		public void OnProcess(string name, string text)
		{
		}

		// Token: 0x0601A7EF RID: 108527 RVA: 0x008344C8 File Offset: 0x008328C8
		public void OnIgnorableSpaces(string s)
		{
		}

		// Token: 0x0601A7F0 RID: 108528 RVA: 0x008344CC File Offset: 0x008328CC
		public void OnStart(string name, MiniXmlParser.IAttributeList attrs)
		{
			SecurityElement securityElement = new SecurityElement(name);
			if (this.root == null)
			{
				this.root = securityElement;
				this.current = securityElement;
			}
			else
			{
				SecurityElement securityElement2 = (SecurityElement)this.stack.Peek();
				securityElement2.AddChild(securityElement);
			}
			this.stack.Push(securityElement);
			this.current = securityElement;
			int attrLength = attrs.AttrLength;
			for (int i = 0; i < attrLength; i++)
			{
				string name2 = SecurityElement.Escape(attrs.GetAttrName(i));
				string value = SecurityElement.Escape(attrs.GetAttrValue(i));
				this.current.AddAttribute(name2, value);
			}
		}

		// Token: 0x0601A7F1 RID: 108529 RVA: 0x0083456D File Offset: 0x0083296D
		public void OnEnd(string name)
		{
			this.current = (SecurityElement)this.stack.Pop();
		}

		// Token: 0x0601A7F2 RID: 108530 RVA: 0x00834585 File Offset: 0x00832985
		public void OnChars(string ch)
		{
			this.current.Text = ch;
		}

		// Token: 0x0601A7F3 RID: 108531 RVA: 0x00834593 File Offset: 0x00832993
		public void OnEndParsing(MiniXmlParser parser)
		{
		}

		// Token: 0x04012923 RID: 76067
		private SecurityElement root;

		// Token: 0x04012924 RID: 76068
		private SecurityElement current;

		// Token: 0x04012925 RID: 76069
		private Stack stack;
	}
}
