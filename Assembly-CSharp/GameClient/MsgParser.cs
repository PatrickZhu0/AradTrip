using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001545 RID: 5445
	public class MsgParser
	{
		// Token: 0x0600D4AA RID: 54442 RVA: 0x0035138C File Offset: 0x0034F78C
		public static bool Parse(string str)
		{
			MsgParser._msgTags.Clear();
			while (str.Length > 0)
			{
				if (MsgParser._msgTags.Count > 100)
				{
					return false;
				}
				if (str[0] == '{')
				{
					str = str.Substring(1);
					if (!MsgParser.ParseTag(ref str))
					{
						return false;
					}
				}
				else
				{
					MsgTag msgTag = new MsgTag();
					MsgParser._msgTags.Add(msgTag);
					msgTag.Type = '\0';
					int num = str.IndexOf('{');
					if (num > 0)
					{
						msgTag.Content = str.Substring(0, num);
						str = str.Substring(num);
					}
					else
					{
						msgTag.Content = str;
						str = string.Empty;
					}
				}
			}
			return true;
		}

		// Token: 0x0600D4AB RID: 54443 RVA: 0x00351444 File Offset: 0x0034F844
		private static bool ParseTag(ref string str)
		{
			if (!MsgParser.IsValidTag(str[0]))
			{
				return false;
			}
			MsgTag msgTag = new MsgTag();
			MsgParser._msgTags.Add(msgTag);
			msgTag.Type = str[0];
			str = str.Substring(1);
			if (!MsgParser.ParseParams(msgTag, ref str))
			{
				return false;
			}
			char c = str[0];
			if (c != '|')
			{
				if (c == '}')
				{
					if (str.Length == 1)
					{
						str = string.Empty;
					}
					else
					{
						str = str.Substring(1);
					}
				}
			}
			else
			{
				str = str.Substring(1);
				while (str[0] == ' ')
				{
					str = str.Substring(1);
				}
				int num = str.IndexOf('}');
				msgTag.Content = str.Substring(0, num);
				if (num + 1 == str.Length)
				{
					str = string.Empty;
				}
				else
				{
					str = str.Substring(num);
				}
			}
			return true;
		}

		// Token: 0x0600D4AC RID: 54444 RVA: 0x00351550 File Offset: 0x0034F950
		private static bool ParseParams(MsgTag tag, ref string str)
		{
			while (tag.Parms.Count < 6)
			{
				while (str[0] == ' ')
				{
					str = str.Substring(1);
				}
				if (str[0] == '|' || str[0] == '}')
				{
					return true;
				}
				string text = string.Empty;
				while (str[0] != ' ' && str[0] != '|' && str[0] != '}')
				{
					text += str[0];
					if (text.Length > 128)
					{
						return false;
					}
					str = str.Substring(1);
				}
				tag.Parms.Add(text);
			}
			return false;
		}

		// Token: 0x0600D4AD RID: 54445 RVA: 0x00351628 File Offset: 0x0034FA28
		private static bool IsValidTag(char tag)
		{
			char[] msgTags = MsgTag.MsgTags;
			for (int i = 0; i < (int)MsgTag.TagNum; i++)
			{
				if (tag == msgTags[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04007CE6 RID: 31974
		private const char MSGTAG_LEFT_SEPARATOR = '{';

		// Token: 0x04007CE7 RID: 31975
		private const char MSGTAG_RIGHT_SEPARATOR = '}';

		// Token: 0x04007CE8 RID: 31976
		private const char MSGTAG_CONTENT_SEPARATOR = '|';

		// Token: 0x04007CE9 RID: 31977
		private const char MSGTAG_PARAM_SEPARATOR = ' ';

		// Token: 0x04007CEA RID: 31978
		private const ushort MAX_TAGPARAM_NUM = 6;

		// Token: 0x04007CEB RID: 31979
		private const ushort MAX_TAGPARAM_LENGTH = 128;

		// Token: 0x04007CEC RID: 31980
		private const ushort MAX_TAG_NUM = 100;

		// Token: 0x04007CED RID: 31981
		protected static List<MsgTag> _msgTags = new List<MsgTag>();
	}
}
