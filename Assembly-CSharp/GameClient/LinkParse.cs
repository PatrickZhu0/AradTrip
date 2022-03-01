using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Parser;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200007C RID: 124
	[ExecuteInEditMode]
	public class LinkParse : MonoBehaviour
	{
		// Token: 0x060002A9 RID: 681 RVA: 0x00014265 File Offset: 0x00012665
		public static string getReplaceString(LinkParse.EmotionSizeType eEmotionSizeType)
		{
			if (eEmotionSizeType >= LinkParse.EmotionSizeType.EST_72 && eEmotionSizeType < LinkParse.EmotionSizeType.EST_COUNT)
			{
				return LinkParse.ms_replace_strings[(int)eEmotionSizeType];
			}
			return LinkParse.ms_replace_strings[0];
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00014284 File Offset: 0x00012684
		public float LinkTextWidth
		{
			get
			{
				return this.m_kTarget.preferredWidth;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060002AB RID: 683 RVA: 0x00014291 File Offset: 0x00012691
		// (set) Token: 0x060002AC RID: 684 RVA: 0x0001429C File Offset: 0x0001269C
		private string text
		{
			get
			{
				return this.m_kText;
			}
			set
			{
				this.m_akLinkInfos.Clear();
				this.m_kText = value;
				this.m_kParsedValue = ((!this.m_bNeedParse) ? value : this.Parse());
				if (this.m_kTarget != null)
				{
					this.m_kTarget.SetLinkText(this.m_kParsedValue, this.m_akLinkInfos);
				}
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00014300 File Offset: 0x00012700
		public static void _TryToken(StringBuilder ms_TextBuilder, string src, int iIndex, List<LinkParse.LinkInfo> akLinkInfo, LinkParse.EmotionSizeType eEmotionSizeType = LinkParse.EmotionSizeType.EST_72)
		{
			if (ms_TextBuilder == null || src == null || iIndex < 0 || iIndex >= src.Length)
			{
				return;
			}
			MyExtensionMethods.Clear(ms_TextBuilder);
			int i = iIndex;
			while (i < src.Length)
			{
				if (src[i] != '{' || i + 1 >= src.Length)
				{
					goto IL_D0F;
				}
				int num = i + 1;
				while (num < src.Length && src[num] != '}')
				{
					num++;
				}
				bool flag = false;
				string text = src.Substring(i + 1, num - i - 1);
				string[] array = text.Split(new char[]
				{
					' '
				});
				string text2 = array[0];
				switch (text2)
				{
				case "F":
					if (array.Length == 2)
					{
						int iParam = 0;
						if (int.TryParse(array[1], out iParam))
						{
							flag = true;
							if (akLinkInfo != null)
							{
								LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
								linkInfo.iParam0 = iParam;
								linkInfo.iStartIndex = ms_TextBuilder.Length;
								ms_TextBuilder.Append(LinkParse.getReplaceString(eEmotionSizeType));
								linkInfo.iEndIndex = ms_TextBuilder.Length;
								linkInfo.eColor = SpriteAssetColor.SAC_COUNT;
								linkInfo.eRegexType = LinkParse.RegexType.RT_EMOTION;
								akLinkInfo.Add(linkInfo);
							}
							else
							{
								ms_TextBuilder.Append(LinkParse.getReplaceString(eEmotionSizeType));
							}
						}
					}
					break;
				case "I":
					if (array.Length == 4)
					{
						ulong guid = 0UL;
						int num3 = 0;
						int num4 = 0;
						if (ulong.TryParse(array[1], out guid) && int.TryParse(array[2], out num3) && int.TryParse(array[3], out num4))
						{
							flag = true;
							if (akLinkInfo != null)
							{
								LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
								linkInfo.guid0 = guid;
								linkInfo.iParam0 = num3;
								linkInfo.iParam1 = num4;
								ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num3, string.Empty, string.Empty);
								ms_TextBuilder.AppendFormat("<color={0}>", ItemParser.GetItemColor(tableItem));
								linkInfo.iStartIndex = ms_TextBuilder.Length;
								ms_TextBuilder.Append("[");
								if (tableItem == null)
								{
									ms_TextBuilder.Append("UnKnown Item");
								}
								else if (num4 <= 0)
								{
									ms_TextBuilder.Append(tableItem.Name);
								}
								else
								{
									ms_TextBuilder.AppendFormat(TR.Value("super_link_item_name"), num4, tableItem.Name);
								}
								ms_TextBuilder.Append("]");
								linkInfo.iEndIndex = ms_TextBuilder.Length;
								linkInfo.eColor = ItemParser.GetAssetColor(tableItem);
								ms_TextBuilder.Append("</color>");
								linkInfo.eRegexType = LinkParse.RegexType.RT_NET_ITEM;
								akLinkInfo.Add(linkInfo);
							}
							else
							{
								ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num3, string.Empty, string.Empty);
								ms_TextBuilder.Append("[");
								if (tableItem2 == null)
								{
									ms_TextBuilder.Append("UnKnown Item");
								}
								else if (num4 <= 0)
								{
									ms_TextBuilder.Append(tableItem2.Name);
								}
								else
								{
									ms_TextBuilder.AppendFormat("+{0} {1}", num4, tableItem2.Name);
								}
								ms_TextBuilder.Append("]");
							}
						}
					}
					break;
				case "R":
					if (array.Length == 3)
					{
					}
					break;
				case "P":
					if (array.Length == 5)
					{
						ulong num5 = 0UL;
						int iParam2 = 0;
						int iParam3 = 0;
						if (ulong.TryParse(array[1], out num5) && int.TryParse(array[3], out iParam2) && int.TryParse(array[4], out iParam3))
						{
							flag = true;
							if (akLinkInfo != null)
							{
								LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
								if (num5 == DataManager<PlayerBaseData>.GetInstance().RoleID)
								{
									ms_TextBuilder.AppendFormat("<color={0}>", "#00c6ff");
									linkInfo.eColor = SpriteAssetColor.SAC_SELF_NAME;
								}
								else
								{
									ms_TextBuilder.AppendFormat("<color={0}>", "#ffd042");
									linkInfo.eColor = SpriteAssetColor.SAC_OTHER_NAME;
								}
								linkInfo.guid0 = num5;
								linkInfo.str0 = array[2];
								linkInfo.iParam0 = iParam2;
								linkInfo.iParam1 = iParam3;
								linkInfo.iStartIndex = ms_TextBuilder.Length;
								ms_TextBuilder.Append(array[2]);
								linkInfo.iEndIndex = ms_TextBuilder.Length;
								ms_TextBuilder.Append("</color>");
								linkInfo.eRegexType = LinkParse.RegexType.RT_PLAYER;
								akLinkInfo.Add(linkInfo);
							}
							else
							{
								ms_TextBuilder.Append(array[2]);
							}
						}
					}
					break;
				case "W":
					if (array.Length == 2)
					{
					}
					break;
				case "O":
					if (array.Length == 3)
					{
						ulong guid2 = 0UL;
						if (ulong.TryParse(array[1], out guid2))
						{
							flag = true;
							if (akLinkInfo != null)
							{
								LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
								linkInfo.guid0 = guid2;
								linkInfo.eColor = SpriteAssetColor.SAC_SELF_NAME;
								ms_TextBuilder.Append(string.Format("<color={0}>", "#00c6ff"));
								linkInfo.iStartIndex = ms_TextBuilder.Length;
								ms_TextBuilder.Append(array[2]);
								linkInfo.iEndIndex = ms_TextBuilder.Length;
								ms_TextBuilder.Append("</color>");
								linkInfo.eRegexType = LinkParse.RegexType.RT_RED_PACKET;
								akLinkInfo.Add(linkInfo);
							}
							else
							{
								ms_TextBuilder.Append(array[2]);
							}
						}
					}
					break;
				case "H":
					if (array.Length == 2)
					{
						flag = true;
						if (akLinkInfo != null)
						{
							LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
							linkInfo.eColor = SpriteAssetColor.SAC_SELF_NAME;
							ms_TextBuilder.Append(string.Format("<color={0}>", "#00c6ff"));
							linkInfo.iStartIndex = ms_TextBuilder.Length;
							ms_TextBuilder.Append(array[1]);
							linkInfo.iEndIndex = ms_TextBuilder.Length;
							ms_TextBuilder.Append("</color>");
							linkInfo.eRegexType = LinkParse.RegexType.RT_JOIN_TABLE;
							akLinkInfo.Add(linkInfo);
						}
						else
						{
							ms_TextBuilder.Append(array[1]);
						}
					}
					break;
				case "D":
					if (array.Length == 2)
					{
						flag = true;
						if (akLinkInfo != null)
						{
							LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
							linkInfo.eColor = SpriteAssetColor.SAC_SELF_NAME;
							ms_TextBuilder.Append(string.Format("<color={0}>", "#00c6ff"));
							linkInfo.iStartIndex = ms_TextBuilder.Length;
							ms_TextBuilder.Append(array[1]);
							linkInfo.iEndIndex = ms_TextBuilder.Length;
							ms_TextBuilder.Append("</color>");
							linkInfo.eRegexType = LinkParse.RegexType.RT_GUILD_SHOP;
							akLinkInfo.Add(linkInfo);
						}
						else
						{
							ms_TextBuilder.Append(array[1]);
						}
					}
					break;
				case "T":
					if (array.Length == 2)
					{
						ulong guid3 = 0UL;
						if (ulong.TryParse(array[1], out guid3))
						{
							flag = true;
							if (akLinkInfo != null)
							{
								LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
								linkInfo.guid0 = guid3;
								linkInfo.eColor = SpriteAssetColor.SAC_BLUE;
								ms_TextBuilder.Append(string.Format("<color={0}>", "#00c6ff"));
								linkInfo.iStartIndex = ms_TextBuilder.Length;
								ms_TextBuilder.Append(TR.Value("JoinTeam"));
								linkInfo.iEndIndex = ms_TextBuilder.Length;
								ms_TextBuilder.Append("</color>");
								linkInfo.eRegexType = LinkParse.RegexType.RT_TEAM_INVITE;
								akLinkInfo.Add(linkInfo);
							}
							else
							{
								ms_TextBuilder.Append(TR.Value("JoinTeam"));
							}
						}
					}
					break;
				case "A":
					if (array.Length == 2)
					{
						flag = true;
						if (akLinkInfo != null)
						{
							LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
							linkInfo.eColor = SpriteAssetColor.SAC_SELF_NAME;
							ms_TextBuilder.Append(string.Format("<color={0}>", "#00c6ff"));
							linkInfo.iStartIndex = ms_TextBuilder.Length;
							ms_TextBuilder.Append(array[1]);
							linkInfo.iEndIndex = ms_TextBuilder.Length;
							ms_TextBuilder.Append("</color>");
							linkInfo.eRegexType = LinkParse.RegexType.RT_GUILD_MANOR;
							akLinkInfo.Add(linkInfo);
						}
						else
						{
							ms_TextBuilder.Append(array[1]);
						}
					}
					break;
				case "M":
					if (array.Length == 2)
					{
						int num6 = 0;
						if (int.TryParse(array[1], out num6))
						{
							LiaoTianDynamicTextureTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<LiaoTianDynamicTextureTable>(num6, string.Empty, string.Empty);
							if (tableItem3 != null)
							{
								flag = true;
								if (akLinkInfo != null)
								{
									LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
									linkInfo.eColor = SpriteAssetColor.SAC_WHITE;
									linkInfo.iStartIndex = ms_TextBuilder.Length;
									ms_TextBuilder.AppendFormat("<quad size={0} width={1} height={2}/>", tableItem3.Size, tableItem3.Width, tableItem3.Height);
									linkInfo.iEndIndex = ms_TextBuilder.Length;
									linkInfo.eRegexType = LinkParse.RegexType.RT_DYNAMIC_IMAGE;
									linkInfo.iParam0 = num6;
									akLinkInfo.Add(linkInfo);
								}
								else
								{
									ms_TextBuilder.Append(text);
								}
							}
						}
					}
					break;
				case "X":
					if (array.Length >= 3)
					{
						int num7 = 0;
						ulong num8 = 0UL;
						ulong guid4 = 0UL;
						bool flag2 = false;
						if (array.Length == 3)
						{
							if (int.TryParse(array[1], out num7) && ulong.TryParse(array[2], out num8))
							{
								flag2 = true;
							}
						}
						else if (array.Length == 4 && int.TryParse(array[1], out num7) && ulong.TryParse(array[2], out num8) && ulong.TryParse(array[3], out guid4))
						{
							flag2 = true;
						}
						if (flag2)
						{
							SuperLinkTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SuperLinkTable>(num7, string.Empty, string.Empty);
							if (tableItem4 != null)
							{
								SuperLinkTable.eLinkType linkType = tableItem4.LinkType;
								if (linkType != SuperLinkTable.eLinkType.LT_DESC)
								{
									if (linkType == SuperLinkTable.eLinkType.LT_TABLE_NAME)
									{
										if (tableItem4.LocalParam.Count == 3)
										{
											Type type = Type.GetType(tableItem4.LocalParam[0]);
											if (type != null)
											{
												object tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem(type, (int)num8, string.Empty, string.Empty);
												if (tableItem5 != null)
												{
													PropertyInfo property = type.GetProperty(tableItem4.LocalParam[1], BindingFlags.Instance | BindingFlags.Public);
													if (property != null)
													{
														string text3 = property.GetValue(tableItem5, null) as string;
														if (text3 != null)
														{
															SpriteAssetColor spriteAssetColor = SpriteAssetColor.SAC_WHITE;
															int num9 = 0;
															if (int.TryParse(tableItem4.LocalParam[2], out num9) && num9 >= 0 && num9 < 14)
															{
																spriteAssetColor = (SpriteAssetColor)num9;
															}
															flag = true;
															if (akLinkInfo != null)
															{
																LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
																linkInfo.eColor = spriteAssetColor;
																ms_TextBuilder.Append("<color=#");
																ms_TextBuilder.Append(NewSuperLinkText.GetColorString(spriteAssetColor));
																ms_TextBuilder.Append(">");
																linkInfo.iStartIndex = ms_TextBuilder.Length;
																ms_TextBuilder.Append(text3);
																linkInfo.iEndIndex = ms_TextBuilder.Length;
																ms_TextBuilder.Append("</color>");
																linkInfo.iParam0 = num7;
																linkInfo.guid0 = num8;
																linkInfo.guid1 = guid4;
																linkInfo.eRegexType = LinkParse.RegexType.RT_SUPER_GROUP;
																akLinkInfo.Add(linkInfo);
															}
															else
															{
																ms_TextBuilder.Append(text3);
															}
														}
													}
												}
											}
										}
									}
								}
								else if (tableItem4.LocalParam.Count == 2)
								{
									flag = true;
									if (akLinkInfo != null)
									{
										LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
										linkInfo.eColor = SpriteAssetColor.SAC_WHITE;
										SpriteAssetColor spriteAssetColor2 = SpriteAssetColor.SAC_WHITE;
										int num10 = 0;
										if (int.TryParse(tableItem4.LocalParam[1], out num10) && num10 >= 0 && num10 < 14)
										{
											spriteAssetColor2 = (SpriteAssetColor)num10;
										}
										linkInfo.eColor = spriteAssetColor2;
										ms_TextBuilder.Append("<color=#");
										ms_TextBuilder.Append(NewSuperLinkText.GetColorString(spriteAssetColor2));
										ms_TextBuilder.Append(">");
										linkInfo.iStartIndex = ms_TextBuilder.Length;
										ms_TextBuilder.Append(tableItem4.LocalParam[0]);
										linkInfo.iEndIndex = ms_TextBuilder.Length;
										ms_TextBuilder.Append("</color>");
										linkInfo.iParam0 = num7;
										linkInfo.guid0 = num8;
										linkInfo.guid1 = guid4;
										linkInfo.eRegexType = LinkParse.RegexType.RT_SUPER_GROUP;
										akLinkInfo.Add(linkInfo);
									}
									else
									{
										ms_TextBuilder.Append(tableItem4.LocalParam[0]);
									}
								}
							}
						}
					}
					break;
				case "U":
					if (array.Length == 4)
					{
						flag = true;
						SpriteAssetColor spriteAssetColor3 = SpriteAssetColor.SAC_ORANGE;
						int num11 = 4;
						if (int.TryParse(array[3], out num11) && num11 >= 0 && num11 < 14)
						{
							spriteAssetColor3 = (SpriteAssetColor)num11;
						}
						ms_TextBuilder.Append("<color=#");
						ms_TextBuilder.Append(NewSuperLinkText.GetColorString(spriteAssetColor3));
						ms_TextBuilder.Append(">");
						if (akLinkInfo != null)
						{
							LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo
							{
								eColor = spriteAssetColor3,
								iStartIndex = ms_TextBuilder.Length,
								eRegexType = LinkParse.RegexType.RT_WEB_URL,
								str0 = array[2]
							};
							ms_TextBuilder.Append(array[1]);
							linkInfo.iEndIndex = ms_TextBuilder.Length;
							akLinkInfo.Add(linkInfo);
						}
						else
						{
							ms_TextBuilder.Append(array[1]);
						}
						ms_TextBuilder.Append("</color>");
					}
					break;
				}
				if (!flag)
				{
					goto IL_D0F;
				}
				i = num;
				IL_D1D:
				i++;
				continue;
				IL_D0F:
				ms_TextBuilder.Append(src[i]);
				goto IL_D1D;
			}
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0001503C File Offset: 0x0001343C
		private string Parse()
		{
			this.m_akLinkInfos.Clear();
			int num = 0;
			MyExtensionMethods.Clear(LinkParse.ms_TextBuilder);
			if (string.IsNullOrEmpty(this.m_kText))
			{
				return string.Empty;
			}
			if (!this.bMissionLink)
			{
				LinkParse._TryToken(LinkParse.ms_TextBuilder, this.m_kText, 0, this.m_akLinkInfos, this.eEmotionSizeType);
				return LinkParse.ms_TextBuilder.ToString();
			}
			for (int i = 0; i < LinkParse.ms_regexs.Length; i++)
			{
				MatchCollection matchCollection = LinkParse.ms_regexs[i].Matches(this.m_kText);
				if (matchCollection != null)
				{
					for (int j = 0; j < matchCollection.Count; j++)
					{
						Match match = matchCollection[j];
						if (match != null && match.Groups.Count > 0 && !string.IsNullOrEmpty(match.Groups[0].Value))
						{
							LinkParse.LinkInfo linkInfo = new LinkParse.LinkInfo();
							linkInfo.eRegexType = (LinkParse.RegexType)i;
							linkInfo.iStartIndex = match.Groups[0].Index;
							linkInfo.iEndIndex = match.Groups[0].Index + match.Groups[0].Length;
							this.m_akLinkInfos.Add(linkInfo);
						}
					}
				}
			}
			if (this.m_akLinkInfos.Count <= 0)
			{
				return this.m_kText;
			}
			this.m_akLinkInfos.Sort((LinkParse.LinkInfo x, LinkParse.LinkInfo y) => x.iStartIndex - y.iStartIndex);
			for (int k = 0; k < this.m_akLinkInfos.Count; k++)
			{
				LinkParse.LinkInfo linkInfo2 = this.m_akLinkInfos[k];
				if (linkInfo2 == null)
				{
					Logger.LogErrorFormat("null reference! value = {0}", new object[]
					{
						this.m_kText
					});
				}
				else if (linkInfo2.iStartIndex < 0 || linkInfo2.iStartIndex >= linkInfo2.iEndIndex || linkInfo2.iEndIndex > this.m_kText.Length)
				{
					Logger.LogErrorFormat("out of index! value = {0}", new object[]
					{
						this.m_kText
					});
				}
				else
				{
					Match match2 = LinkParse.ms_regexs[(int)linkInfo2.eRegexType].Match(this.m_kText, linkInfo2.iStartIndex, linkInfo2.iEndIndex - linkInfo2.iStartIndex);
					if (match2 == null || match2.Groups.Count < 0 || string.IsNullOrEmpty(match2.Groups[0].Value))
					{
						Logger.LogErrorFormat("parse error! value = {0}", new object[]
						{
							this.m_kText
						});
						this.m_akLinkInfos.RemoveAt(k--);
					}
					else
					{
						LinkParse.ms_TextBuilder.Append(this.m_kText.Substring(num, match2.Groups[0].Index - num));
						LinkParse.RegexType eRegexType = linkInfo2.eRegexType;
						if (eRegexType == LinkParse.RegexType.RT_LOCAL)
						{
							ParserReturn parserReturn = this.OnParse(match2.Groups[1].Value, match2.Groups[2].Value);
							LinkParse.ms_TextBuilder.Append(string.Format("<color={0}>", parserReturn.color));
							linkInfo2.str0 = match2.Groups[1].Value;
							linkInfo2.iParam0 = (int)parserReturn.iId;
							linkInfo2.eColor = SpriteAssetColor.SAC_COUNT;
							linkInfo2.iStartIndex = LinkParse.ms_TextBuilder.Length;
							LinkParse.ms_TextBuilder.Append(parserReturn.content);
							linkInfo2.iEndIndex = LinkParse.ms_TextBuilder.Length;
							LinkParse.ms_TextBuilder.Append("</color>");
						}
						num = match2.Groups[0].Index + match2.Groups[0].Length;
					}
				}
			}
			if (!string.IsNullOrEmpty(this.m_kText))
			{
				LinkParse.ms_TextBuilder.Append(this.m_kText.Substring(num, this.m_kText.Length - num));
			}
			return LinkParse.ms_TextBuilder.ToString();
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00015480 File Offset: 0x00013880
		protected ParserReturn OnParse(string key, string value)
		{
			ParserReturn result;
			result.color = "0xFFFFFF";
			result.content = string.Empty;
			result.iId = 0U;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string text = string.Empty;
			if (key.Length > 0)
			{
				text = key.Substring(0, 1);
				text = text.ToUpper();
				if (key.Length > 1)
				{
					text += key.Substring(1, key.Length - 1);
				}
			}
			if (text.Length <= 0)
			{
				return result;
			}
			string typeName = "Parser." + text + "Parser";
			object obj = executingAssembly.CreateInstance(typeName);
			if (obj != null)
			{
				IParser parser = obj as IParser;
				if (parser != null)
				{
					return parser.OnParse(value);
				}
			}
			return result;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00015540 File Offset: 0x00013940
		public void SetText(string value, bool bNeedParse = true)
		{
			this.m_bNeedParse = bNeedParse;
			this.text = value;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00015550 File Offset: 0x00013950
		public void AddListener(NewSuperLinkText.OnClickItem listener)
		{
			if (this.m_kTarget != null)
			{
				NewSuperLinkText kTarget = this.m_kTarget;
				kTarget.onClickItem = (NewSuperLinkText.OnClickItem)Delegate.Combine(kTarget.onClickItem, listener);
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0001557F File Offset: 0x0001397F
		public void RemoveListener(NewSuperLinkText.OnClickItem listener)
		{
			if (this.m_kTarget != null)
			{
				NewSuperLinkText kTarget = this.m_kTarget;
				kTarget.onClickItem = (NewSuperLinkText.OnClickItem)Delegate.Remove(kTarget.onClickItem, listener);
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x000155AE File Offset: 0x000139AE
		public void AddListener(NewSuperLinkText.OnClickPlayerName listener)
		{
			if (this.m_kTarget != null)
			{
				NewSuperLinkText kTarget = this.m_kTarget;
				kTarget.onClickPlayerName = (NewSuperLinkText.OnClickPlayerName)Delegate.Combine(kTarget.onClickPlayerName, listener);
			}
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x000155DD File Offset: 0x000139DD
		public void RemoveListener(NewSuperLinkText.OnClickPlayerName listener)
		{
			if (this.m_kTarget != null)
			{
				NewSuperLinkText kTarget = this.m_kTarget;
				kTarget.onClickPlayerName = (NewSuperLinkText.OnClickPlayerName)Delegate.Remove(kTarget.onClickPlayerName, listener);
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0001560C File Offset: 0x00013A0C
		public void AddListener(NewSuperLinkText.OnClickLocalLink listener)
		{
			if (this.m_kTarget != null)
			{
				NewSuperLinkText kTarget = this.m_kTarget;
				kTarget.onClickLocalLink = (NewSuperLinkText.OnClickLocalLink)Delegate.Combine(kTarget.onClickLocalLink, listener);
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0001563B File Offset: 0x00013A3B
		public void RemoveListener(NewSuperLinkText.OnClickLocalLink listener)
		{
			if (this.m_kTarget != null)
			{
				NewSuperLinkText kTarget = this.m_kTarget;
				kTarget.onClickLocalLink = (NewSuperLinkText.OnClickLocalLink)Delegate.Remove(kTarget.onClickLocalLink, listener);
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0001566A File Offset: 0x00013A6A
		public void AddListener(NewSuperLinkText.OnClickRetinueLink listener)
		{
			if (this.m_kTarget != null)
			{
				NewSuperLinkText kTarget = this.m_kTarget;
				kTarget.onClickRetinueLink = (NewSuperLinkText.OnClickRetinueLink)Delegate.Combine(kTarget.onClickRetinueLink, listener);
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00015699 File Offset: 0x00013A99
		public void RemoveListener(NewSuperLinkText.OnClickRetinueLink listener)
		{
			if (this.m_kTarget != null)
			{
				NewSuperLinkText kTarget = this.m_kTarget;
				kTarget.onClickRetinueLink = (NewSuperLinkText.OnClickRetinueLink)Delegate.Remove(kTarget.onClickRetinueLink, listener);
			}
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x000156C8 File Offset: 0x00013AC8
		public void AddListener(NewSuperLinkText.OnClickWrapStoneLink listener)
		{
			if (this.m_kTarget != null)
			{
				NewSuperLinkText kTarget = this.m_kTarget;
				kTarget.onClickWrapStoneLink = (NewSuperLinkText.OnClickWrapStoneLink)Delegate.Combine(kTarget.onClickWrapStoneLink, listener);
			}
		}

		// Token: 0x060002BA RID: 698 RVA: 0x000156F7 File Offset: 0x00013AF7
		public void RemoveListener(NewSuperLinkText.OnClickWrapStoneLink listener)
		{
			if (this.m_kTarget != null)
			{
				NewSuperLinkText kTarget = this.m_kTarget;
				kTarget.onClickWrapStoneLink = (NewSuperLinkText.OnClickWrapStoneLink)Delegate.Remove(kTarget.onClickWrapStoneLink, listener);
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00015726 File Offset: 0x00013B26
		public void AddOnFailedListener(UnityAction listener)
		{
			if (this.m_kTarget != null)
			{
				this.m_kTarget.AddFailedCallBack(listener);
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00015745 File Offset: 0x00013B45
		public void RemoveFailedListener(UnityAction listener)
		{
			if (this.m_kTarget != null)
			{
				this.m_kTarget.RemoveFailedCallBack(listener);
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00015764 File Offset: 0x00013B64
		public void RemoveAllDelegate()
		{
			if (this.m_kTarget != null)
			{
				this.m_kTarget.RemoveAllDelegate();
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00015784 File Offset: 0x00013B84
		public static bool IsLink(string value)
		{
			for (int i = 0; i < 14; i++)
			{
				Match match = LinkParse.ms_regexs[i].Match(value);
				if (!string.IsNullOrEmpty(match.Groups[0].Value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0400028E RID: 654
		private static readonly Regex[] ms_regexs = new Regex[]
		{
			new Regex("{F (\\d*\\.?\\d+%?)}", RegexOptions.Singleline),
			new Regex("{I (\\d*\\.?\\d+%?) (\\d*\\.?\\d+%?)}", RegexOptions.Singleline),
			new Regex("<a href=([^>\\n\\s]+)>(.*?)(</a>)", RegexOptions.Singleline),
			new Regex("{P (\\d+) (\\w+) (\\d+) (\\d+)}", RegexOptions.Singleline),
			new Regex("{R (\\d*\\.?\\d+%?) (\\d*\\.?\\d+%?)}", RegexOptions.Singleline),
			new Regex("{W (\\d*\\.?\\d+%?)}", RegexOptions.Singleline),
			new Regex("{O (\\d+) (\\w+)}", RegexOptions.Singleline),
			new Regex("{H (\\w+)}", RegexOptions.Singleline),
			new Regex("{D (\\w+)}", RegexOptions.Singleline),
			new Regex("{T (\\d+)}", RegexOptions.Singleline),
			new Regex("{A (\\w+)}"),
			new Regex("{M (\\d+)}", RegexOptions.Singleline),
			new Regex("{X (\\d+) (\\d+) (\\d+)}", RegexOptions.Singleline),
			new Regex("{U (\\w+) ^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$} (\\d+) ", RegexOptions.Singleline)
		};

		// Token: 0x0400028F RID: 655
		private static readonly Regex ms_system_left_color = new Regex("<color=(.)+>", RegexOptions.Singleline);

		// Token: 0x04000290 RID: 656
		private static readonly StringBuilder ms_TextBuilder = StringBuilderCache.Acquire(1024);

		// Token: 0x04000291 RID: 657
		private static readonly string[] ms_replace_strings = new string[]
		{
			"<quad size=72 width=1 height=1/>",
			"<quad size=36 width=1 height=1/>",
			"<quad size=34 width=1 height=1/>"
		};

		// Token: 0x04000292 RID: 658
		public LinkParse.EmotionSizeType eEmotionSizeType;

		// Token: 0x04000293 RID: 659
		private List<LinkParse.LinkInfo> m_akLinkInfos = new List<LinkParse.LinkInfo>();

		// Token: 0x04000294 RID: 660
		private string m_kText = string.Empty;

		// Token: 0x04000295 RID: 661
		private string m_kParsedValue = string.Empty;

		// Token: 0x04000296 RID: 662
		private bool m_bNeedParse = true;

		// Token: 0x04000297 RID: 663
		public NewSuperLinkText m_kTarget;

		// Token: 0x04000298 RID: 664
		public bool bMissionLink = true;

		// Token: 0x0200007D RID: 125
		public enum RegexType
		{
			// Token: 0x0400029C RID: 668
			RT_EMOTION,
			// Token: 0x0400029D RID: 669
			RT_NET_ITEM,
			// Token: 0x0400029E RID: 670
			RT_LOCAL,
			// Token: 0x0400029F RID: 671
			RT_PLAYER,
			// Token: 0x040002A0 RID: 672
			RT_RETINUE,
			// Token: 0x040002A1 RID: 673
			RT_ENERGY_STONE,
			// Token: 0x040002A2 RID: 674
			RT_RED_PACKET,
			// Token: 0x040002A3 RID: 675
			RT_JOIN_TABLE,
			// Token: 0x040002A4 RID: 676
			RT_GUILD_SHOP,
			// Token: 0x040002A5 RID: 677
			RT_TEAM_INVITE,
			// Token: 0x040002A6 RID: 678
			RT_GUILD_MANOR,
			// Token: 0x040002A7 RID: 679
			RT_DYNAMIC_IMAGE,
			// Token: 0x040002A8 RID: 680
			RT_SUPER_GROUP,
			// Token: 0x040002A9 RID: 681
			RT_WEB_URL,
			// Token: 0x040002AA RID: 682
			RT_COUNT
		}

		// Token: 0x0200007E RID: 126
		public enum EmotionSizeType
		{
			// Token: 0x040002AC RID: 684
			EST_72,
			// Token: 0x040002AD RID: 685
			EST_36,
			// Token: 0x040002AE RID: 686
			EST_34,
			// Token: 0x040002AF RID: 687
			EST_COUNT
		}

		// Token: 0x0200007F RID: 127
		public class LinkInfo
		{
			// Token: 0x040002B0 RID: 688
			public LinkParse.RegexType eRegexType = LinkParse.RegexType.RT_COUNT;

			// Token: 0x040002B1 RID: 689
			public int iStartIndex;

			// Token: 0x040002B2 RID: 690
			public int iEndIndex;

			// Token: 0x040002B3 RID: 691
			public SpriteAssetColor eColor;

			// Token: 0x040002B4 RID: 692
			public Bounds bounds;

			// Token: 0x040002B5 RID: 693
			public List<Bounds> allBounds = new List<Bounds>();

			// Token: 0x040002B6 RID: 694
			public bool bNeedRemove;

			// Token: 0x040002B7 RID: 695
			public int iParam0;

			// Token: 0x040002B8 RID: 696
			public int iParam1;

			// Token: 0x040002B9 RID: 697
			public int iParam2;

			// Token: 0x040002BA RID: 698
			public ulong guid0;

			// Token: 0x040002BB RID: 699
			public ulong guid1;

			// Token: 0x040002BC RID: 700
			public string str0;

			// Token: 0x040002BD RID: 701
			public string str1;
		}
	}
}
