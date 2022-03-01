using System;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016B9 RID: 5817
	public class GetItemEffectFrame : ClientFrame
	{
		// Token: 0x0600E41E RID: 58398 RVA: 0x003AFD26 File Offset: 0x003AE126
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Tip/GetItemEffect";
		}

		// Token: 0x0600E41F RID: 58399 RVA: 0x003AFD30 File Offset: 0x003AE130
		private void SetObjChangeWidthTween(string strPath, float fDelta)
		{
			GameObject obj = Utility.FindChild(base.GetFrame(), strPath);
			if (obj != null)
			{
				Tweener tweener = DOTween.To(delegate()
				{
					if (obj != null)
					{
						return obj.GetComponent<RectTransform>().sizeDelta.y;
					}
					return 0f;
				}, delegate(float y)
				{
					if (obj != null)
					{
						Vector2 sizeDelta = obj.GetComponent<RectTransform>().sizeDelta;
						sizeDelta.y = y;
						obj.GetComponent<RectTransform>().sizeDelta = sizeDelta;
					}
				}, obj.GetComponent<RectTransform>().sizeDelta.y + fDelta, 0.2f);
				TweenSettingsExtensions.SetEase<Tweener>(tweener, 27);
			}
		}

		// Token: 0x0600E420 RID: 58400 RVA: 0x003AFDAC File Offset: 0x003AE1AC
		public void AddNewItem(ItemData kItem, bool bHighValue = false)
		{
			if (kItem == null)
			{
				return;
			}
			if (this.m_arrGetItemInfo == null)
			{
				return;
			}
			GetItemEffectFrame.ItemDataEx itemDataEx = new GetItemEffectFrame.ItemDataEx();
			itemDataEx.itemData = kItem;
			itemDataEx.bHighValue = bHighValue;
			this.m_arrGetItemInfo.Add(itemDataEx);
			if (bHighValue)
			{
				this.bHaveHighValueItem = true;
			}
		}

		// Token: 0x0600E421 RID: 58401 RVA: 0x003AFDFC File Offset: 0x003AE1FC
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
			this.fFrameCreateTime = Time.realtimeSinceStartup;
			this.fTimeElapsed = 0f;
			this.fTimeElapsedDelay = 0f;
			this.fScrollPos = 0f;
			this.bUpdatePos = false;
			this.fInterval = 0.2f;
			this.bHaveHighValueItem = false;
			if (this.goItem != null)
			{
				this.goItem.CustomActive(false);
			}
			if (this.m_effXingGuang != null)
			{
				this.m_effXingGuang.CustomActive(false);
			}
			if (this.m_effGuanYun != null)
			{
				this.m_effGuanYun.CustomActive(false);
			}
			if (this.m_btnExit != null)
			{
				this.m_btnExit.onClick.RemoveAllListeners();
				this.m_btnExit.onClick.AddListener(delegate()
				{
					if (Time.realtimeSinceStartup - this.fFrameCreateTime < 1f)
					{
						return;
					}
					this.frameMgr.CloseFrame<GetItemEffectFrame>(null, false);
				});
			}
			InvokeMethod.Invoke(this, 0.5f, delegate()
			{
				if (this.m_arrGetItemInfo.Count <= 8)
				{
					this.fInterval = 0.2f;
				}
				else
				{
					this.fInterval = 0.1f;
				}
			});
			if (this.btSnap != null)
			{
				this.btSnap.CustomActive(false);
			}
		}

		// Token: 0x0600E422 RID: 58402 RVA: 0x003AFF1C File Offset: 0x003AE31C
		private void _UpdateEffect()
		{
			if (this.m_effXingGuang != null)
			{
				this.m_effXingGuang.CustomActive(true);
			}
			if (this.m_effGuanYun != null)
			{
				this.m_effGuanYun.CustomActive(true);
			}
			if (this.m_arrGetItemInfo == null)
			{
				return;
			}
			if (this.m_arrGetItemInfo.Count > 0)
			{
				ItemData itemData = this.m_arrGetItemInfo[0].itemData;
				if (itemData != null && this.goItem != null && this.goContent != null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.goItem);
					Utility.AttachTo(gameObject, this.goContent, false);
					gameObject.CustomActive(true);
					GetItemEffectItem component = gameObject.GetComponent<GetItemEffectItem>();
					if (component != null)
					{
						if (this.goItems != null)
						{
							if (this.goContent.transform.childCount > 4)
							{
								if (this.goContent.transform.childCount <= 8)
								{
									Vector2 sizeDelta = this.goItems.gameObject.GetComponent<RectTransform>().sizeDelta;
									sizeDelta.y = 400f;
									this.goItems.gameObject.GetComponent<RectTransform>().sizeDelta = sizeDelta;
								}
								else
								{
									Vector2 sizeDelta2 = this.goItems.gameObject.GetComponent<RectTransform>().sizeDelta;
									sizeDelta2.y = 600f;
									this.goItems.gameObject.GetComponent<RectTransform>().sizeDelta = sizeDelta2;
								}
							}
							if (this.goContent.transform.childCount == 5)
							{
								Vector3 localPosition = this.goItems.transform.localPosition;
								localPosition.y += 50f;
								this.goItems.transform.localPosition = localPosition;
							}
						}
						if (this.goContent.transform.childCount == 5)
						{
							this.SetObjChangeWidthTween("BG (3)", 100f);
						}
						else if (this.goContent.transform.childCount == 9)
						{
							this.SetObjChangeWidthTween("BG (3)", 205f);
						}
						if ((this.goContent.transform.childCount - 9) % 4 == 0 && this.goContent.transform.childCount > 1)
						{
							Tweener tweener = DOTween.To(delegate()
							{
								if (this.m_scrollRect != null)
								{
									return this.m_scrollRect.normalizedPosition.y;
								}
								return 0f;
							}, delegate(float y)
							{
								this.fScrollPos = y;
							}, 0f, 0.2f);
							this.bUpdatePos = true;
							TweenSettingsExtensions.OnComplete<Tweener>(tweener, delegate()
							{
								this.bUpdatePos = false;
							});
						}
						component.SetUp(itemData, 0f, this, this.m_arrGetItemInfo[0].bHighValue);
						this.m_arrEffecItem.Add(component);
					}
				}
				this.m_arrGetItemInfo.RemoveAt(0);
				if (this.m_arrGetItemInfo.Count != 0 || this.bHaveHighValueItem)
				{
				}
			}
		}

		// Token: 0x0600E423 RID: 58403 RVA: 0x003B020C File Offset: 0x003AE60C
		protected override void _OnCloseFrame()
		{
			this.bHaveHighValueItem = false;
			InvokeMethod.RemoveInvokeCall(this);
			this.m_arrGetItemInfo.Clear();
			for (int i = 0; i < this.m_arrEffecItem.Count; i++)
			{
				if (this.m_arrEffecItem[i].gameObject != null)
				{
					Object.Destroy(this.m_arrEffecItem[i].gameObject);
					this.m_arrEffecItem[i] = null;
				}
			}
			this.m_arrEffecItem.Clear();
			this.UnBindUIEvent();
		}

		// Token: 0x0600E424 RID: 58404 RVA: 0x003B029D File Offset: 0x003AE69D
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600E425 RID: 58405 RVA: 0x003B02A0 File Offset: 0x003AE6A0
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeElapsedDelay += timeElapsed;
			this.fTimeElapsed += timeElapsed;
			if (this.fTimeElapsedDelay >= 0.5f && this.fTimeElapsed >= this.fInterval)
			{
				this.fTimeElapsed = 0f;
				this._UpdateEffect();
			}
			if (this.goDesc != null && this.goBg3 != null)
			{
				Vector3 localPosition = this.goDesc.transform.localPosition;
				localPosition.y = this.goBg3.transform.localPosition.y - this.goBg3.transform.GetComponent<RectTransform>().sizeDelta.y - 40f;
				this.goDesc.transform.localPosition = localPosition;
			}
			if (this.bUpdatePos)
			{
				this.m_scrollRect.normalizedPosition = new Vector2(this.m_scrollRect.normalizedPosition.x, this.fScrollPos);
			}
		}

		// Token: 0x0600E426 RID: 58406 RVA: 0x003B03B8 File Offset: 0x003AE7B8
		private void CaptureSnap(string name)
		{
			Texture2D texture2D = new Texture2D(Screen.width, Screen.height, 3, true);
			if (texture2D == null)
			{
				return;
			}
			texture2D.ReadPixels(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), 0, 0, true);
			texture2D.Apply();
			byte[] bytes = texture2D.EncodeToPNG();
			File.WriteAllBytes(name, bytes);
		}

		// Token: 0x0600E427 RID: 58407 RVA: 0x003B041C File Offset: 0x003AE81C
		protected override void _bindExUI()
		{
			this.btSnap = this.mBind.GetCom<Button>("btSnap");
			if (this.btSnap != null)
			{
				this.btSnap.onClick.RemoveAllListeners();
				this.btSnap.onClick.AddListener(delegate()
				{
					UIGray uigray = this.btSnap.gameObject.SafeAddComponent(false);
					if (uigray != null)
					{
						uigray.enabled = true;
					}
					if (this.btSnapText != null)
					{
						this.btSnapText.text = TR.Value("haveSnapPic");
					}
					if (this.btSnap != null)
					{
						this.btSnap.interactable = false;
						this.btSnap.image.raycastTarget = false;
					}
					TakePhotoModeFrame.MobileScreenShoot(null, 0f, 0f, 1f, 1f);
				});
			}
			this.btSnapText = this.mBind.GetCom<Text>("btSnapText");
		}

		// Token: 0x0600E428 RID: 58408 RVA: 0x003B0492 File Offset: 0x003AE892
		protected override void _unbindExUI()
		{
			this.btSnap = null;
			this.btSnapText = null;
		}

		// Token: 0x0600E429 RID: 58409 RVA: 0x003B04A2 File Offset: 0x003AE8A2
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FirstPayFrameOpen, new ClientEventSystem.UIEventHandler(this._OnFirstPayFrameOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SecondPayFrameOpen, new ClientEventSystem.UIEventHandler(this._OnSecondPayFrameOpen));
		}

		// Token: 0x0600E42A RID: 58410 RVA: 0x003B04DA File Offset: 0x003AE8DA
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FirstPayFrameOpen, new ClientEventSystem.UIEventHandler(this._OnFirstPayFrameOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SecondPayFrameOpen, new ClientEventSystem.UIEventHandler(this._OnSecondPayFrameOpen));
		}

		// Token: 0x0600E42B RID: 58411 RVA: 0x003B0514 File Offset: 0x003AE914
		private void _OnFirstPayFrameOpen(UIEvent uiEvent)
		{
			FirstPayFrame firstPayFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(FirstPayFrame)) as FirstPayFrame;
			if (firstPayFrame == null)
			{
				return;
			}
			GameObject frame = firstPayFrame.GetFrame();
			if (firstPayFrame != null && frame != null)
			{
				this.frame.transform.SetSiblingIndex(frame.transform.GetSiblingIndex() + 1);
			}
		}

		// Token: 0x0600E42C RID: 58412 RVA: 0x003B0578 File Offset: 0x003AE978
		private void _OnSecondPayFrameOpen(UIEvent uiEvent)
		{
			SecondPayFrame secondPayFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(SecondPayFrame)) as SecondPayFrame;
			if (secondPayFrame == null)
			{
				return;
			}
			GameObject frame = secondPayFrame.GetFrame();
			if (secondPayFrame != null && frame != null)
			{
				this.frame.transform.SetSiblingIndex(frame.transform.GetSiblingIndex() + 1);
			}
		}

		// Token: 0x04008903 RID: 35075
		[UIObject("Items/Item")]
		private GameObject goItem;

		// Token: 0x04008904 RID: 35076
		[UIObject("Items/ScrollView/ViewPort/Content")]
		private GameObject goContent;

		// Token: 0x04008905 RID: 35077
		[UIControl("Items/ScrollView", null, 0)]
		private ScrollRect m_scrollRect;

		// Token: 0x04008906 RID: 35078
		[UIObject("EffUI_gongxihuode_guangyun")]
		private GameObject m_effGuanYun;

		// Token: 0x04008907 RID: 35079
		[UIObject("EffUI_gongxihuode_xingguang")]
		private GameObject m_effXingGuang;

		// Token: 0x04008908 RID: 35080
		[UIControl("btnExit", null, 0)]
		private Button m_btnExit;

		// Token: 0x04008909 RID: 35081
		[UIObject("Items")]
		private GameObject goItems;

		// Token: 0x0400890A RID: 35082
		[UIObject("Desc")]
		private GameObject goDesc;

		// Token: 0x0400890B RID: 35083
		[UIObject("BG (3)")]
		private GameObject goBg3;

		// Token: 0x0400890C RID: 35084
		private Button btSnap;

		// Token: 0x0400890D RID: 35085
		private Text btSnapText;

		// Token: 0x0400890E RID: 35086
		private List<GetItemEffectItem> m_arrEffecItem = new List<GetItemEffectItem>();

		// Token: 0x0400890F RID: 35087
		private float fScrollPos;

		// Token: 0x04008910 RID: 35088
		private bool bUpdatePos;

		// Token: 0x04008911 RID: 35089
		private List<GetItemEffectFrame.ItemDataEx> m_arrGetItemInfo = new List<GetItemEffectFrame.ItemDataEx>();

		// Token: 0x04008912 RID: 35090
		private bool bHaveHighValueItem;

		// Token: 0x04008913 RID: 35091
		private float fFrameCreateTime = Time.realtimeSinceStartup;

		// Token: 0x04008914 RID: 35092
		private const float fInterval1 = 0.2f;

		// Token: 0x04008915 RID: 35093
		private const float fInterval2 = 0.1f;

		// Token: 0x04008916 RID: 35094
		private const float fDelayTime = 0.5f;

		// Token: 0x04008917 RID: 35095
		private float fTimeElapsed;

		// Token: 0x04008918 RID: 35096
		private float fTimeElapsedDelay;

		// Token: 0x04008919 RID: 35097
		private float fInterval;

		// Token: 0x020016BA RID: 5818
		private class ItemDataEx
		{
			// Token: 0x0400891A RID: 35098
			public ItemData itemData;

			// Token: 0x0400891B RID: 35099
			public bool bHighValue;
		}
	}
}
