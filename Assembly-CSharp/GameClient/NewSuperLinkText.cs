using System;
using System.Collections.Generic;
using System.Reflection;
using Parser;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000087 RID: 135
	public class NewSuperLinkText : Text, IPointerClickHandler, IPointerDownHandler, IEventSystemHandler
	{
		// Token: 0x060002DF RID: 735 RVA: 0x00016164 File Offset: 0x00014564
		public static string GetColorString(SpriteAssetColor eSpriteAssetColor)
		{
			Color color = Color.white;
			if (eSpriteAssetColor >= SpriteAssetColor.SAC_WHITE && eSpriteAssetColor < (SpriteAssetColor)NewSuperLinkText.ms_akColors.Length)
			{
				color = NewSuperLinkText.ms_akColors[(int)eSpriteAssetColor];
			}
			byte b = (byte)(255f * color.r);
			byte b2 = (byte)(255f * color.g);
			byte b3 = (byte)(255f * color.b);
			byte b4 = (byte)(255f * color.a);
			return string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", new object[]
			{
				b,
				b2,
				b3,
				b4
			});
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0001620E File Offset: 0x0001460E
		public override float preferredWidth
		{
			get
			{
				if (this.fMaxWidth < 0f)
				{
					return base.preferredWidth;
				}
				if (this.fMaxWidth < base.preferredWidth)
				{
					return this.fMaxWidth;
				}
				return base.preferredWidth;
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00016248 File Offset: 0x00014648
		private void _EnableImages(int iValidCount)
		{
			for (int i = 0; i < this.m_ImagesPool.Count; i++)
			{
				this.m_ImagesPool[i].enabled = (i < iValidCount);
				if (!this.m_ImagesPool[i].enabled)
				{
					this.m_ImagesPool[i].sprite = null;
					this.m_ImagesPool[i].material = null;
				}
			}
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000162C0 File Offset: 0x000146C0
		private void _EnableSpriteRenders(int iValidCount)
		{
			for (int i = 0; i < this.m_spriteRenders.Count; i++)
			{
				this.m_spriteRenders[i].img.enabled = (i < iValidCount);
				if (!this.m_spriteRenders[i].img.enabled)
				{
					this.m_spriteRenders[i].img.sprite = null;
					this.m_spriteRenders[i].img.material = null;
				}
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0001634C File Offset: 0x0001474C
		protected override void OnDestroy()
		{
			this.m_akLinkInfos.Clear();
			this.m_ImagesPool.Clear();
			this.m_spriteAsset = null;
			this.m_spriteGraphic = null;
			this.m_underLineGraphic = null;
			this.m_akTempVertex.Clear();
			this.m_akIndexs.Clear();
			this.RemoveAllDelegate();
			base.OnDestroy();
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x000163A8 File Offset: 0x000147A8
		protected override void Awake()
		{
			base.Awake();
			this.m_spriteGraphic = Utility.FindComponent<SpriteGraphic>(base.gameObject, "SpriteGraphic", true);
			this.m_spriteGraphic.LoadDefault();
			this.m_underLineGraphic = Utility.FindComponent<UnderLineGraphic>(base.gameObject, "UnderLineGraphic", true);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000163F4 File Offset: 0x000147F4
		protected override void OnPopulateMesh(VertexHelper toFill)
		{
			if (this.m_akLinkInfos.Count <= 0)
			{
				base.OnPopulateMesh(toFill);
				return;
			}
			this.OnPopulateNewMesh(toFill);
			this._SetEmotionVertexDirty();
			this._SetUnderLineVertexsDirty();
			this._DrawDynamicImages();
			this._DrawSpriteRenders();
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00016430 File Offset: 0x00014830
		protected void OnPopulateNewMesh(VertexHelper toFill)
		{
			if (base.font == null)
			{
				return;
			}
			this.m_DisableFontTextureRebuiltCallback = true;
			Vector2 size = base.rectTransform.rect.size;
			TextGenerationSettings generationSettings = base.GetGenerationSettings(size);
			base.cachedTextGenerator.Populate(this.text, generationSettings);
			Rect rect = base.rectTransform.rect;
			Vector2 textAnchorPivot = Text.GetTextAnchorPivot(generationSettings.textAnchor);
			Vector2 zero = Vector2.zero;
			zero.x = Mathf.Lerp(rect.xMin, rect.xMax, textAnchorPivot.x);
			zero.y = Mathf.Lerp(rect.yMin, rect.yMax, textAnchorPivot.y);
			Vector2 vector = base.PixelAdjustPoint(zero) - zero;
			IList<UIVertex> verts = base.cachedTextGenerator.verts;
			float num = 1f / base.pixelsPerUnit;
			int num2 = verts.Count - 4;
			for (int i = 0; i < this.m_akLinkInfos.Count; i++)
			{
				LinkParse.LinkInfo linkInfo = this.m_akLinkInfos[i];
				linkInfo.bNeedRemove = true;
				linkInfo.allBounds.Clear();
				int num3 = linkInfo.iStartIndex * 4;
				int num4 = linkInfo.iEndIndex * 4;
				if (linkInfo != null && num4 <= num2)
				{
					linkInfo.bNeedRemove = false;
					Bounds item = default(Bounds);
					Vector3 vector2 = Vector3.zero;
					for (int j = num3; j < num4; j++)
					{
						if (j < 0 || j >= num2)
						{
							Logger.LogErrorFormat("out of index j = {0} toFill.currentVertCount={1}", new object[]
							{
								j,
								num2
							});
							linkInfo.bNeedRemove = true;
							break;
						}
						if (vector != Vector2.zero)
						{
							this.m_kVertex = verts[j];
							this.m_kVertex.position = this.m_kVertex.position * num;
							this.m_kVertex.position.x = this.m_kVertex.position.x + vector.x;
							this.m_kVertex.position.y = this.m_kVertex.position.y + vector.y;
						}
						else
						{
							this.m_kVertex = verts[j];
							this.m_kVertex.position = this.m_kVertex.position * num;
						}
						if (j == num3)
						{
							item..ctor(this.m_kVertex.position, Vector3.zero);
						}
						else if (j % 4 == 0 && vector2.x > this.m_kVertex.position.x)
						{
							linkInfo.allBounds.Add(item);
							item..ctor(this.m_kVertex.position, Vector3.zero);
						}
						else
						{
							item.Encapsulate(this.m_kVertex.position);
						}
						vector2 = this.m_kVertex.position;
						if (linkInfo.eRegexType == LinkParse.RegexType.RT_EMOTION || linkInfo.eRegexType == LinkParse.RegexType.RT_DYNAMIC_IMAGE)
						{
							this.m_kVertex.position = Vector3.zero;
						}
					}
					if (item.size.x > 0f && item.size.y > 0f)
					{
						linkInfo.allBounds.Add(item);
					}
					if (linkInfo.allBounds.Count > 0)
					{
						linkInfo.bounds = linkInfo.allBounds[0];
					}
				}
			}
			this.m_akLinkInfos.RemoveAll((LinkParse.LinkInfo x) => x.bNeedRemove);
			toFill.Clear();
			if (num2 >= NewSuperLinkText.ms_abVertexBytePool.Length)
			{
				Logger.LogErrorFormat("the max flags pool size is {0}", new object[]
				{
					NewSuperLinkText.ms_abVertexBytePool.Length
				});
				this.m_DisableFontTextureRebuiltCallback = false;
				return;
			}
			int num5 = 0;
			while (num5 < NewSuperLinkText.ms_abVertexBytePool.Length && num5 < num2)
			{
				NewSuperLinkText.ms_abVertexBytePool[num5] = 1;
				num5++;
			}
			for (int k = 0; k < this.m_akLinkInfos.Count; k++)
			{
				int num6 = this.m_akLinkInfos[k].iStartIndex * 4;
				int num7 = this.m_akLinkInfos[k].iEndIndex * 4;
				if (num6 >= 0 && num7 <= num2)
				{
					if (!this.m_akLinkInfos[k].bNeedRemove)
					{
						if (this.m_akLinkInfos[k].eRegexType == LinkParse.RegexType.RT_EMOTION || this.m_akLinkInfos[k].eRegexType == LinkParse.RegexType.RT_DYNAMIC_IMAGE)
						{
							for (int l = num6; l < num7; l++)
							{
								NewSuperLinkText.ms_abVertexBytePool[l] = 0;
							}
						}
					}
				}
			}
			if (vector != Vector2.zero)
			{
				for (int m = 0; m < num2; m++)
				{
					int num8 = m & 3;
					this.m_TempVerts[num8] = verts[m];
					UIVertex[] tempVerts = this.m_TempVerts;
					int num9 = num8;
					tempVerts[num9].position = tempVerts[num9].position * num;
					UIVertex[] tempVerts2 = this.m_TempVerts;
					int num10 = num8;
					tempVerts2[num10].position.x = tempVerts2[num10].position.x + vector.x;
					UIVertex[] tempVerts3 = this.m_TempVerts;
					int num11 = num8;
					tempVerts3[num11].position.y = tempVerts3[num11].position.y + vector.y;
					if (NewSuperLinkText.ms_abVertexBytePool[m] != 0)
					{
						if (num8 == 3)
						{
							toFill.AddUIVertexQuad(this.m_TempVerts);
						}
					}
				}
			}
			else
			{
				for (int n = 0; n < num2; n++)
				{
					int num12 = n & 3;
					this.m_TempVerts[num12] = verts[n];
					UIVertex[] tempVerts4 = this.m_TempVerts;
					int num13 = num12;
					tempVerts4[num13].position = tempVerts4[num13].position * num;
					if (NewSuperLinkText.ms_abVertexBytePool[n] != 0)
					{
						if (num12 == 3)
						{
							toFill.AddUIVertexQuad(this.m_TempVerts);
						}
					}
				}
			}
			this.m_DisableFontTextureRebuiltCallback = false;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00016A8A File Offset: 0x00014E8A
		public void AddFailedCallBack(UnityAction callback)
		{
			this.onFailed = (UnityAction)Delegate.Combine(this.onFailed, callback);
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00016AA3 File Offset: 0x00014EA3
		public void RemoveFailedCallBack(UnityAction callback)
		{
			this.onFailed = (UnityAction)Delegate.Remove(this.onFailed, callback);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00016ABC File Offset: 0x00014EBC
		private void _CreateBounds(VertexHelper toFill)
		{
			for (int i = 0; i < this.m_akLinkInfos.Count; i++)
			{
				LinkParse.LinkInfo linkInfo = this.m_akLinkInfos[i];
				linkInfo.bNeedRemove = true;
				linkInfo.allBounds.Clear();
				int num = linkInfo.iStartIndex * 4;
				int num2 = linkInfo.iEndIndex * 4;
				if (linkInfo != null && num2 <= toFill.currentVertCount)
				{
					linkInfo.bNeedRemove = false;
					Bounds item = default(Bounds);
					Vector3 vector = Vector3.zero;
					for (int j = num; j < num2; j++)
					{
						if (j < 0 || j >= toFill.currentVertCount)
						{
							Logger.LogErrorFormat("out of index j = {0} toFill.currentVertCount={1}", new object[]
							{
								j,
								toFill.currentVertCount
							});
							linkInfo.bNeedRemove = true;
							break;
						}
						toFill.PopulateUIVertex(ref this.m_kVertex, j);
						if (j == num)
						{
							item..ctor(this.m_kVertex.position, Vector3.zero);
						}
						else if (j % 4 == 0 && vector.x > this.m_kVertex.position.x)
						{
							linkInfo.allBounds.Add(item);
							item..ctor(this.m_kVertex.position, Vector3.zero);
						}
						else
						{
							item.Encapsulate(this.m_kVertex.position);
						}
						vector = this.m_kVertex.position;
						if (linkInfo.eRegexType == LinkParse.RegexType.RT_EMOTION || linkInfo.eRegexType == LinkParse.RegexType.RT_DYNAMIC_IMAGE)
						{
							this.m_kVertex.position = Vector3.zero;
						}
					}
					if (item.size.x > 0f && item.size.y > 0f)
					{
						linkInfo.allBounds.Add(item);
					}
					if (linkInfo.allBounds.Count > 0)
					{
						linkInfo.bounds = linkInfo.allBounds[0];
					}
				}
			}
			this.m_akLinkInfos.RemoveAll((LinkParse.LinkInfo x) => x.bNeedRemove);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00016CF8 File Offset: 0x000150F8
		private void _SetEmotionVertexDirty()
		{
			if (this.m_spriteGraphic != null)
			{
				this.m_spriteGraphic.BeginDraw();
				for (int i = 0; i < this.m_akLinkInfos.Count; i++)
				{
					LinkParse.LinkInfo linkInfo = this.m_akLinkInfos[i];
					if (linkInfo != null && linkInfo.eRegexType == LinkParse.RegexType.RT_EMOTION)
					{
						if (linkInfo.allBounds.Count > 0)
						{
							float fX = linkInfo.bounds.center.x - linkInfo.bounds.size.x / 2f;
							float fY = linkInfo.bounds.center.y - linkInfo.bounds.size.y / 2f + (float)(base.fontSize / 2) - linkInfo.bounds.size.y / 2f;
							float x = linkInfo.bounds.size.x;
							float y = linkInfo.bounds.size.y;
							this.m_spriteGraphic.DrawSprite(linkInfo.iParam0, fX, fY, x, y, Color.white);
						}
					}
				}
				this.m_spriteGraphic.EndDraw();
			}
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00016E4C File Offset: 0x0001524C
		private void _SetUnderLineVertexsDirty()
		{
			if (this.m_underLineGraphic != null)
			{
				this.m_underLineGraphic.BeginDraw();
				for (int i = 0; i < this.m_akLinkInfos.Count; i++)
				{
					LinkParse.LinkInfo linkInfo = this.m_akLinkInfos[i];
					if (linkInfo != null && linkInfo.eColor != SpriteAssetColor.SAC_COUNT && linkInfo.eRegexType != LinkParse.RegexType.RT_DYNAMIC_IMAGE && !linkInfo.bNeedRemove)
					{
						if (linkInfo.eRegexType == LinkParse.RegexType.RT_SUPER_GROUP)
						{
						}
						for (int j = 0; j < linkInfo.allBounds.Count; j++)
						{
							float fX = linkInfo.allBounds[j].center.x - linkInfo.allBounds[j].size.x / 2f;
							float fY = linkInfo.allBounds[j].center.y - linkInfo.allBounds[j].size.y / 2f;
							float x = linkInfo.allBounds[j].size.x;
							float fH = 2f;
							this.m_underLineGraphic.DrawRect(fX, fY, x, fH, NewSuperLinkText.ms_akColors[(int)linkInfo.eColor]);
						}
					}
				}
				this.m_underLineGraphic.EndDraw();
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00016FDC File Offset: 0x000153DC
		private void _SetDynamicImages()
		{
			this.m_iValidCount = 0;
			for (int i = 0; i < this.m_akLinkInfos.Count; i++)
			{
				LinkParse.LinkInfo linkInfo = this.m_akLinkInfos[i];
				if (linkInfo != null && linkInfo.eRegexType == LinkParse.RegexType.RT_DYNAMIC_IMAGE)
				{
					LiaoTianDynamicTextureTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<LiaoTianDynamicTextureTable>(linkInfo.iParam0, string.Empty, string.Empty);
					if (tableItem != null && tableItem.Type == LiaoTianDynamicTextureTable.eType.Image)
					{
						this.m_iValidCount++;
						Image image = null;
						if (this.m_ImagesPool.Count < this.m_iValidCount)
						{
							GameObject gameObject = new GameObject("Img", new Type[]
							{
								typeof(Image)
							});
							image = gameObject.GetComponent<Image>();
							Utility.AttachTo(gameObject, base.gameObject, false);
							image.CustomActive(true);
							this.m_ImagesPool.Add(image);
						}
						else
						{
							image = this.m_ImagesPool[this.m_iValidCount - 1];
						}
						image.rectTransform.anchorMin = base.rectTransform.anchorMin;
						image.rectTransform.anchorMax = base.rectTransform.anchorMax;
						image.rectTransform.pivot = Vector2.zero;
						image.rectTransform.sizeDelta = new Vector2(((float)tableItem.Size - 2f) * 1f / (float)tableItem.Height * (float)tableItem.Width, (float)tableItem.Size - 2f);
						ETCImageLoader.LoadSprite(ref image, tableItem.Icon, true);
					}
				}
			}
			this._EnableImages(this.m_iValidCount);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00017180 File Offset: 0x00015580
		private void _SetDynamicFrameSprites()
		{
			this.m_iRenderCount = 0;
			for (int i = 0; i < this.m_akLinkInfos.Count; i++)
			{
				LinkParse.LinkInfo linkInfo = this.m_akLinkInfos[i];
				if (linkInfo != null && linkInfo.eRegexType == LinkParse.RegexType.RT_DYNAMIC_IMAGE)
				{
					LiaoTianDynamicTextureTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<LiaoTianDynamicTextureTable>(linkInfo.iParam0, string.Empty, string.Empty);
					if (tableItem != null && tableItem.Type == LiaoTianDynamicTextureTable.eType.FrameSprite)
					{
						this.m_iRenderCount++;
						NewSuperLinkText.SpriteRenderInfo spriteRenderInfo;
						if (this.m_spriteRenders.Count < this.m_iRenderCount)
						{
							GameObject gameObject = new GameObject("Sprite", new Type[]
							{
								typeof(Image),
								typeof(SpriteAniRender)
							});
							spriteRenderInfo = new NewSuperLinkText.SpriteRenderInfo
							{
								spriteRender = gameObject.GetComponent<SpriteAniRender>(),
								img = gameObject.GetComponent<Image>()
							};
							Utility.AttachTo(gameObject, base.gameObject, false);
							spriteRenderInfo.img.CustomActive(true);
							this.m_spriteRenders.Add(spriteRenderInfo);
						}
						else
						{
							spriteRenderInfo = this.m_spriteRenders[this.m_iRenderCount - 1];
						}
						spriteRenderInfo.img.rectTransform.anchorMin = base.rectTransform.anchorMin;
						spriteRenderInfo.img.rectTransform.anchorMax = base.rectTransform.anchorMax;
						spriteRenderInfo.img.rectTransform.pivot = Vector2.zero;
						spriteRenderInfo.img.rectTransform.sizeDelta = new Vector2(((float)tableItem.Size - 2f) * 1f / (float)tableItem.Height * (float)tableItem.Width, (float)tableItem.Size - 2f);
						spriteRenderInfo.spriteRender.orgPath = tableItem.Param[0];
						spriteRenderInfo.spriteRender.orgName = tableItem.Param[1];
						spriteRenderInfo.spriteRender.count = int.Parse(tableItem.Param[2]);
						spriteRenderInfo.spriteRender.looptimes = 0;
						spriteRenderInfo.spriteRender.playinterval = int.Parse(tableItem.Param[3]);
						spriteRenderInfo.spriteRender.Reset(tableItem.Param[0], tableItem.Param[1], int.Parse(tableItem.Param[2]), ((float)tableItem.Size - 2f) * 1f / (float)tableItem.Height);
					}
				}
			}
			this._EnableSpriteRenders(this.m_iRenderCount);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0001741C File Offset: 0x0001581C
		private void _DrawDynamicImages()
		{
			this.m_iValidCount = 0;
			for (int i = 0; i < this.m_akLinkInfos.Count; i++)
			{
				LinkParse.LinkInfo linkInfo = this.m_akLinkInfos[i];
				if (linkInfo != null && linkInfo.eRegexType == LinkParse.RegexType.RT_DYNAMIC_IMAGE)
				{
					LiaoTianDynamicTextureTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<LiaoTianDynamicTextureTable>(linkInfo.iParam0, string.Empty, string.Empty);
					if (tableItem != null && tableItem.Type == LiaoTianDynamicTextureTable.eType.Image)
					{
						this.m_iValidCount++;
						Bounds bounds = linkInfo.allBounds[0];
						float num = bounds.center.x - this.m_ImagesPool[this.m_iValidCount - 1].rectTransform.sizeDelta.x / 2f;
						float num2 = bounds.center.y - this.m_ImagesPool[this.m_iValidCount - 1].rectTransform.sizeDelta.y / 2f;
						float x = bounds.size.x;
						float y = bounds.size.y;
						if (this.m_iValidCount <= this.m_ImagesPool.Count)
						{
							this.m_ImagesPool[this.m_iValidCount - 1].rectTransform.anchoredPosition = new Vector2(num, num2);
						}
					}
				}
			}
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0001759C File Offset: 0x0001599C
		private void _DrawSpriteRenders()
		{
			this.m_iRenderCount = 0;
			for (int i = 0; i < this.m_akLinkInfos.Count; i++)
			{
				LinkParse.LinkInfo linkInfo = this.m_akLinkInfos[i];
				if (linkInfo != null && linkInfo.eRegexType == LinkParse.RegexType.RT_DYNAMIC_IMAGE)
				{
					LiaoTianDynamicTextureTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<LiaoTianDynamicTextureTable>(linkInfo.iParam0, string.Empty, string.Empty);
					if (tableItem != null && tableItem.Type == LiaoTianDynamicTextureTable.eType.FrameSprite)
					{
						this.m_iRenderCount++;
						Bounds bounds = linkInfo.allBounds[0];
						float num = bounds.center.x - this.m_spriteRenders[this.m_iRenderCount - 1].img.rectTransform.sizeDelta.x / 2f;
						float num2 = bounds.center.y - this.m_spriteRenders[this.m_iRenderCount - 1].img.rectTransform.sizeDelta.y / 2f;
						float x = bounds.size.x;
						float y = bounds.size.y;
						if (this.m_iRenderCount <= this.m_spriteRenders.Count)
						{
							this.m_spriteRenders[this.m_iRenderCount - 1].img.rectTransform.anchoredPosition = new Vector2(num, num2);
						}
					}
				}
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0001772C File Offset: 0x00015B2C
		private void _AddEffectiveTextVertexs(VertexHelper toFill)
		{
			this.m_akIndexs.Clear();
			this.m_akTempVertex.Clear();
			if (toFill.currentVertCount <= 0)
			{
				return;
			}
			if (toFill.currentIndexCount >= NewSuperLinkText.ms_abVertexBytePool.Length)
			{
				Logger.LogErrorFormat("the max flags pool size is {0}", new object[]
				{
					NewSuperLinkText.ms_abVertexBytePool.Length
				});
				return;
			}
			int num = 0;
			while (num < NewSuperLinkText.ms_abVertexBytePool.Length && num < toFill.currentIndexCount)
			{
				NewSuperLinkText.ms_abVertexBytePool[num] = 1;
				num++;
			}
			for (int i = 0; i < this.m_akLinkInfos.Count; i++)
			{
				int num2 = this.m_akLinkInfos[i].iStartIndex * 4;
				int num3 = this.m_akLinkInfos[i].iEndIndex * 4;
				if (num2 < 0 || num3 > toFill.currentVertCount)
				{
					Logger.LogErrorFormat("out of index!", new object[0]);
				}
				else if (!this.m_akLinkInfos[i].bNeedRemove)
				{
					if (this.m_akLinkInfos[i].eRegexType == LinkParse.RegexType.RT_EMOTION || this.m_akLinkInfos[i].eRegexType == LinkParse.RegexType.RT_DYNAMIC_IMAGE)
					{
						for (int j = num2; j < num3; j++)
						{
							NewSuperLinkText.ms_abVertexBytePool[j] = 0;
						}
					}
				}
			}
			for (int k = 0; k < toFill.currentVertCount; k++)
			{
				if (NewSuperLinkText.ms_abVertexBytePool[k] == 1)
				{
					toFill.PopulateUIVertex(ref this.m_kVertex, k);
					this.m_akTempVertex.Add(this.m_kVertex);
				}
			}
			this.m_akIndexs.Clear();
			for (int l = 0; l < this.m_akTempVertex.Count; l++)
			{
				if (l % 4 == 0)
				{
					this.m_akIndexs.Add(l);
					this.m_akIndexs.Add(l + 1);
					this.m_akIndexs.Add(l + 2);
					this.m_akIndexs.Add(l + 2);
					this.m_akIndexs.Add(l);
					this.m_akIndexs.Add(l + 3);
				}
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00017965 File Offset: 0x00015D65
		private void _DrawEffectiveTextVertex(VertexHelper toFill)
		{
			if (toFill != null)
			{
				toFill.Clear();
				toFill.AddUIVertexStream(this.m_akTempVertex, this.m_akIndexs);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00017985 File Offset: 0x00015D85
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x00017990 File Offset: 0x00015D90
		public override string text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					if (string.IsNullOrEmpty(this.m_Text))
					{
						return;
					}
					this.m_Text = string.Empty;
					this.SetVerticesDirty();
				}
				else
				{
					this.m_Text = value;
					this.SetVerticesDirty();
					this.SetLayoutDirty();
				}
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x000179E4 File Offset: 0x00015DE4
		public void SetLinkText(string value, List<LinkParse.LinkInfo> links)
		{
			this.m_akLinkInfos = links;
			this.text = value;
			if (null != this.m_spriteGraphic)
			{
				this.m_spriteGraphic.BeginDraw();
				this.m_spriteGraphic.EndDraw();
				this.m_spriteGraphic.SetVerticesDirty();
			}
			if (null != this.m_underLineGraphic)
			{
				this.m_underLineGraphic.BeginDraw();
				this.m_underLineGraphic.EndDraw();
				this.m_underLineGraphic.SetVerticesDirty();
			}
			this._SetDynamicImages();
			this._SetDynamicFrameSprites();
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00017A6F File Offset: 0x00015E6F
		public void AddListener(NewSuperLinkText.OnClickItem listener)
		{
			this.onClickItem = (NewSuperLinkText.OnClickItem)Delegate.Combine(this.onClickItem, listener);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00017A88 File Offset: 0x00015E88
		public void RemoveListener(NewSuperLinkText.OnClickItem listener)
		{
			this.onClickItem = (NewSuperLinkText.OnClickItem)Delegate.Remove(this.onClickItem, listener);
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00017AA1 File Offset: 0x00015EA1
		public void AddListener(NewSuperLinkText.OnClickPlayerName listener)
		{
			this.onClickPlayerName = (NewSuperLinkText.OnClickPlayerName)Delegate.Combine(this.onClickPlayerName, listener);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00017ABA File Offset: 0x00015EBA
		public void RemoveListener(NewSuperLinkText.OnClickPlayerName listener)
		{
			this.onClickPlayerName = (NewSuperLinkText.OnClickPlayerName)Delegate.Remove(this.onClickPlayerName, listener);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00017AD3 File Offset: 0x00015ED3
		public void AddListener(NewSuperLinkText.OnClickLocalLink listener)
		{
			this.onClickLocalLink = (NewSuperLinkText.OnClickLocalLink)Delegate.Combine(this.onClickLocalLink, listener);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00017AEC File Offset: 0x00015EEC
		public void RemoveListener(NewSuperLinkText.OnClickLocalLink listener)
		{
			this.onClickLocalLink = (NewSuperLinkText.OnClickLocalLink)Delegate.Remove(this.onClickLocalLink, listener);
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00017B05 File Offset: 0x00015F05
		public void AddListener(NewSuperLinkText.OnClickRetinueLink listener)
		{
			this.onClickRetinueLink = (NewSuperLinkText.OnClickRetinueLink)Delegate.Combine(this.onClickRetinueLink, listener);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00017B1E File Offset: 0x00015F1E
		public void RemoveListener(NewSuperLinkText.OnClickRetinueLink listener)
		{
			this.onClickRetinueLink = (NewSuperLinkText.OnClickRetinueLink)Delegate.Remove(this.onClickRetinueLink, listener);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00017B37 File Offset: 0x00015F37
		public void AddListener(NewSuperLinkText.OnClickWrapStoneLink listener)
		{
			this.onClickWrapStoneLink = (NewSuperLinkText.OnClickWrapStoneLink)Delegate.Combine(this.onClickWrapStoneLink, listener);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00017B50 File Offset: 0x00015F50
		public void RemoveListener(NewSuperLinkText.OnClickWrapStoneLink listener)
		{
			this.onClickWrapStoneLink = (NewSuperLinkText.OnClickWrapStoneLink)Delegate.Remove(this.onClickWrapStoneLink, listener);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00017B69 File Offset: 0x00015F69
		public void RemoveAllDelegate()
		{
			this.onClickItem = null;
			this.onClickPlayerName = null;
			this.onClickLocalLink = null;
			this.onClickRetinueLink = null;
			this.onClickWrapStoneLink = null;
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00017B90 File Offset: 0x00015F90
		public void OnPointerClick(PointerEventData eventData)
		{
			bool flag = false;
			if (this.m_akLinkInfos.Count > 0)
			{
				Vector2 vector;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, eventData.position, eventData.pressEventCamera, ref vector);
				for (int i = 0; i < this.m_akLinkInfos.Count; i++)
				{
					LinkParse.LinkInfo linkInfo = this.m_akLinkInfos[i];
					if (linkInfo != null && !linkInfo.bNeedRemove && linkInfo.allBounds.Count > 0)
					{
						for (int j = 0; j < linkInfo.allBounds.Count; j++)
						{
							Rect rect;
							rect..ctor(linkInfo.allBounds[j].min, linkInfo.allBounds[j].size);
							if (rect.Contains(vector))
							{
								flag = true;
								this._OnClickLink(linkInfo);
								break;
							}
						}
					}
				}
			}
			if (!flag && this.onFailed != null)
			{
				this.onFailed.Invoke();
			}
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00017CAE File Offset: 0x000160AE
		public void OnPointerDown(PointerEventData eventData)
		{
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00017CB0 File Offset: 0x000160B0
		private void _OnClickLink(LinkParse.LinkInfo linkInfo)
		{
			IClientSystem currentSystem = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem();
			if (currentSystem != null && currentSystem is ClientSystemBattle)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("jump_smithshopframe_tips"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (linkInfo == null)
			{
				return;
			}
			switch (linkInfo.eRegexType)
			{
			case LinkParse.RegexType.RT_NET_ITEM:
				if (this.onClickItem != null)
				{
					this.onClickItem(linkInfo.guid0, linkInfo.iParam0, linkInfo.iParam1);
				}
				else
				{
					DataManager<LinkManager>.GetInstance().AttachDatas = null;
					ItemParser.OnItemLink(linkInfo.guid0, linkInfo.iParam0, 0U, 0U);
				}
				break;
			case LinkParse.RegexType.RT_LOCAL:
				if (this.onClickLocalLink != null)
				{
					this.onClickLocalLink(linkInfo.iParam0, linkInfo.str0);
				}
				break;
			case LinkParse.RegexType.RT_PLAYER:
				if (this.onClickPlayerName != null)
				{
					this.onClickPlayerName(linkInfo.guid0, linkInfo.str0, (byte)linkInfo.iParam0, (uint)linkInfo.iParam1);
				}
				else
				{
					Common.NameParse(linkInfo.guid0, (byte)linkInfo.iParam0, linkInfo.str0);
				}
				break;
			case LinkParse.RegexType.RT_RETINUE:
				if (this.onClickRetinueLink != null)
				{
					this.onClickRetinueLink(linkInfo.guid0, linkInfo.iParam0);
				}
				else
				{
					Common.RetinueParse(linkInfo.guid0, linkInfo.iParam0);
				}
				break;
			case LinkParse.RegexType.RT_ENERGY_STONE:
				if (this.onClickWrapStoneLink != null)
				{
					this.onClickWrapStoneLink(linkInfo.iParam0);
				}
				break;
			case LinkParse.RegexType.RT_RED_PACKET:
			{
				RedPacketBaseEntry redPacketBaseInfo = DataManager<RedPackDataManager>.GetInstance().GetRedPacketBaseInfo(linkInfo.guid0);
				if (redPacketBaseInfo != null)
				{
					if (redPacketBaseInfo.status == 2 && redPacketBaseInfo.opened == 0)
					{
						DataManager<RedPackDataManager>.GetInstance().OpenRedPacket(redPacketBaseInfo.id);
					}
					else
					{
						DataManager<RedPackDataManager>.GetInstance().CheckRedPacket(redPacketBaseInfo.id);
					}
				}
				else
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_redpacket_invalid"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				break;
			}
			case LinkParse.RegexType.RT_JOIN_TABLE:
				if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenBuildingFrame, GuildBuildingType.TABLE, null, null, null);
				}
				else
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				break;
			case LinkParse.RegexType.RT_GUILD_SHOP:
			{
				GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
				if (myGuild != null && myGuild.dictBuildings != null)
				{
					GuildBuildingData guildBuildingData = null;
					myGuild.dictBuildings.TryGetValue(GuildBuildingType.SHOP, out guildBuildingData);
					if (guildBuildingData != null)
					{
						int nLevel = guildBuildingData.nLevel;
						GuildBuildingTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(nLevel, string.Empty, string.Empty);
						if (tableItem != null)
						{
							DataManager<ShopDataManager>.GetInstance().OpenShop(tableItem.ShopId, 0, -1, delegate
							{
								Singleton<ClientSystemManager>.instance.OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenShopFrame, null, null, null, null);
							}, null, ShopFrame.ShopFrameMode.SFM_MAIN_FRAME, 0, -1);
							DataManager<RedPointDataManager>.GetInstance().ClearRedPoint(ERedPoint.GuildShop);
						}
					}
				}
				break;
			}
			case LinkParse.RegexType.RT_TEAM_INVITE:
				if (DataManager<TeamDataManager>.GetInstance().HasTeam())
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_already_has_team"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
					if (clientSystemTown == null)
					{
						return;
					}
					CitySceneTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
					if (tableItem2 == null)
					{
						return;
					}
					if (tableItem2.SceneType == CitySceneTable.eSceneType.PK_PREPARE && PkWaitingRoom.bBeginSeekPlayer)
					{
						SystemNotifyManager.SystemNotify(4004, string.Empty);
						return;
					}
					if (linkInfo.guid0 == DataManager<PlayerBaseData>.GetInstance().RoleID)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("队伍不存在", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else
					{
						DataManager<TeamDataManager>.GetInstance().JoinTeam(linkInfo.guid0);
					}
				}
				break;
			case LinkParse.RegexType.RT_GUILD_MANOR:
				Singleton<ClientSystemManager>.instance.OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
				if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenCrossManorFrame, null, null, null, null);
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenManorFrame, null, null, null, null);
				}
				break;
			case LinkParse.RegexType.RT_SUPER_GROUP:
			{
				SuperLinkTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SuperLinkTable>(linkInfo.iParam0, string.Empty, string.Empty);
				if (tableItem3 != null && !string.IsNullOrEmpty(tableItem3.LinkInfo))
				{
					try
					{
						bool flag = true;
						int num = 1;
						if (tableItem3.OpenLevel.Count == 3)
						{
							try
							{
								Type type = Type.GetType(tableItem3.OpenLevel[0]);
								if (type != null)
								{
									string s = string.Format(tableItem3.OpenLevel[2], new object[]
									{
										linkInfo.guid0,
										linkInfo.guid1,
										linkInfo.str0,
										linkInfo.str1
									});
									int id = 0;
									if (int.TryParse(s, out id))
									{
										object tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem(type, id, string.Empty, string.Empty);
										if (tableItem4 != null)
										{
											PropertyInfo property = type.GetProperty(tableItem3.OpenLevel[1], BindingFlags.Instance | BindingFlags.Public);
											if (property != null)
											{
												num = (int)property.GetValue(tableItem4, null);
												flag = ((int)DataManager<PlayerBaseData>.GetInstance().Level >= num);
											}
										}
									}
								}
							}
							catch (Exception ex)
							{
								flag = true;
								Logger.LogErrorFormat("READ UNLOCKLEVEL FAILED:\n {0},{1},{2},{3}", new object[]
								{
									tableItem3.OpenLevel[0],
									tableItem3.OpenLevel[1],
									tableItem3.OpenLevel[2],
									tableItem3.OpenLevel[3]
								});
							}
						}
						if (flag)
						{
							string text = string.Format(tableItem3.LinkInfo, new object[]
							{
								linkInfo.guid0,
								linkInfo.guid1,
								linkInfo.str0,
								linkInfo.str1
							});
							if (!string.IsNullOrEmpty(text))
							{
								DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(text, null, false);
							}
						}
						else
						{
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("common_can_not_goto", num), CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
					}
					catch (Exception ex2)
					{
						Logger.LogErrorFormat("superLinkItem ID = {0} info={1} p1={2} p2={3} p3={4} p4={5}", new object[]
						{
							linkInfo.iParam0,
							tableItem3.LinkInfo,
							linkInfo.guid0,
							linkInfo.guid1,
							linkInfo.str0,
							linkInfo.str1
						});
					}
				}
				break;
			}
			case LinkParse.RegexType.RT_WEB_URL:
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OperateAdsBoardFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<OperateAdsBoardFrame>(null, false);
				}
				string name = (!Singleton<PluginManager>.GetInstance().IsMGSDKChannel()) ? TR.Value("operateAds_community") : TR.Value("operateAds_website");
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<OperateAdsBoardFrame>(FrameLayer.TopMoreMost, linkInfo.str0, name);
				break;
			}
			}
		}

		// Token: 0x040002D3 RID: 723
		private static byte[] ms_abVertexBytePool = new byte[4096];

		// Token: 0x040002D4 RID: 724
		private static Color[] ms_akColors = new Color[]
		{
			Color.white,
			new Color(0f, 0.75f, 1f),
			new Color(0.75f, 0f, 1f),
			new Color(1f, 0f, 0.75f),
			new Color(1f, 0.75f, 0f),
			new Color(0f, 1f, 0f),
			new Color(1f, 0.8157f, 0.2588f),
			new Color(0f, 0.78f, 1f),
			new Color(1f, 0f, 0f),
			new Color(0f, 1f, 0.2824f),
			new Color(1f, 0.9647f, 0f),
			new Color(0f, 0.6353f, 1f),
			new Color(0.898f, 0.4353f, 0.9137f),
			new Color(1f, 0f, 0.35f)
		};

		// Token: 0x040002D5 RID: 725
		public static string[] ms_stringColors = new string[]
		{
			"FFFFFFFF",
			"00BFFFFF",
			"770887FF",
			"770887FF",
			"770887FF",
			"770887FF",
			"770887FF",
			"770887FF",
			"770887FF",
			"770887FF",
			"770887FF",
			"770887FF",
			"770887FF",
			"770887FF"
		};

		// Token: 0x040002D6 RID: 726
		public float fMaxWidth = -1f;

		// Token: 0x040002D7 RID: 727
		private List<LinkParse.LinkInfo> m_akLinkInfos = new List<LinkParse.LinkInfo>();

		// Token: 0x040002D8 RID: 728
		private SpriteAsset m_spriteAsset;

		// Token: 0x040002D9 RID: 729
		private SpriteGraphic m_spriteGraphic;

		// Token: 0x040002DA RID: 730
		private UnderLineGraphic m_underLineGraphic;

		// Token: 0x040002DB RID: 731
		private UIVertex m_kVertex;

		// Token: 0x040002DC RID: 732
		private List<UIVertex> m_akTempVertex = new List<UIVertex>();

		// Token: 0x040002DD RID: 733
		private List<int> m_akIndexs = new List<int>();

		// Token: 0x040002DE RID: 734
		public NewSuperLinkText.OnClickItem onClickItem;

		// Token: 0x040002DF RID: 735
		public NewSuperLinkText.OnClickPlayerName onClickPlayerName;

		// Token: 0x040002E0 RID: 736
		public NewSuperLinkText.OnClickLocalLink onClickLocalLink;

		// Token: 0x040002E1 RID: 737
		public NewSuperLinkText.OnClickRetinueLink onClickRetinueLink;

		// Token: 0x040002E2 RID: 738
		public NewSuperLinkText.OnClickWrapStoneLink onClickWrapStoneLink;

		// Token: 0x040002E3 RID: 739
		private readonly List<Image> m_ImagesPool = new List<Image>();

		// Token: 0x040002E4 RID: 740
		private int m_iValidCount;

		// Token: 0x040002E5 RID: 741
		private readonly List<NewSuperLinkText.SpriteRenderInfo> m_spriteRenders = new List<NewSuperLinkText.SpriteRenderInfo>();

		// Token: 0x040002E6 RID: 742
		private int m_iRenderCount;

		// Token: 0x040002E7 RID: 743
		private readonly UIVertex[] m_TempVerts = new UIVertex[4];

		// Token: 0x040002E8 RID: 744
		private UnityAction onFailed;

		// Token: 0x02000088 RID: 136
		// (Invoke) Token: 0x06000308 RID: 776
		public delegate void OnClickItem(ulong guid, int dataid, int strengthLv);

		// Token: 0x02000089 RID: 137
		// (Invoke) Token: 0x0600030C RID: 780
		public delegate void OnClickPlayerName(ulong guid, string name, byte occu, uint level);

		// Token: 0x0200008A RID: 138
		// (Invoke) Token: 0x06000310 RID: 784
		public delegate void OnClickLocalLink(int iParam0, string name);

		// Token: 0x0200008B RID: 139
		// (Invoke) Token: 0x06000314 RID: 788
		public delegate void OnClickRetinueLink(ulong guid, int dataid);

		// Token: 0x0200008C RID: 140
		// (Invoke) Token: 0x06000318 RID: 792
		public delegate void OnClickWrapStoneLink(int iParam0);

		// Token: 0x0200008D RID: 141
		private class SpriteRenderInfo
		{
			// Token: 0x040002EC RID: 748
			public SpriteAniRender spriteRender;

			// Token: 0x040002ED RID: 749
			public Image img;
		}
	}
}
