using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02004943 RID: 18755
[Serializable]
public class ETCButton : ETCBase, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEventSystemHandler
{
	// Token: 0x0601AF6C RID: 110444 RVA: 0x0084B7B8 File Offset: 0x00849BB8
	public ETCButton()
	{
		this.axis = new ETCAxis("Button");
		this._visible = true;
		this._activated = true;
		this.isOnTouch = false;
		this.enableKeySimulation = true;
		this.axis.unityAxis = "Jump";
		this.showPSInspector = true;
		this.showSpriteInspector = false;
		this.showBehaviourInspector = false;
		this.showEventInspector = false;
	}

	// Token: 0x0601AF6D RID: 110445 RVA: 0x0084B847 File Offset: 0x00849C47
	protected override void Awake()
	{
		base.Awake();
		this.cachedImage = base.GetComponent<Image>();
		this.fgCoolDownText.enabled = false;
	}

	// Token: 0x0601AF6E RID: 110446 RVA: 0x0084B868 File Offset: 0x00849C68
	public override void Start()
	{
		this.axis.InitAxis();
		base.Start();
		this.isOnPress = false;
		if (this.allowSimulationStandalone && this.enableKeySimulation && !Application.isEditor)
		{
			this.SetVisible(this.visibleOnStandalone);
		}
		GameObject gameObject = Utility.FindGameObject(base.gameObject, "buff_bg", false);
		if (gameObject != null)
		{
			this.imgBuffBg = gameObject.GetComponent<Image>();
			this.goBuffBg = gameObject;
			this.goBuffBg.SetActive(false);
		}
		gameObject = Utility.FindGameObject(base.gameObject, "buff", false);
		if (gameObject != null)
		{
			this.imgBuff = gameObject.GetComponent<Image>();
			this.goBuff = gameObject;
			this.goBuff.SetActive(false);
		}
	}

	// Token: 0x0601AF6F RID: 110447 RVA: 0x0084B934 File Offset: 0x00849D34
	public override void OnDestroy()
	{
		this.normalSprite = null;
		this.pressedSprite = null;
		this.coolDownSprite = null;
		this.coolDownImage = null;
		this.coolDownRect = null;
		this.fgSprite = null;
		this.fgCoolDownText = null;
		this.fgImage = null;
		this.fgRect = null;
		this.imgBuffBg = null;
		this.imgBuff = null;
		this.goBuffBg = null;
		this.goBuff = null;
		this.buff = null;
		this.cachedImage = null;
		this.previousDargObject = null;
		base.OnDestroy();
	}

	// Token: 0x0601AF70 RID: 110448 RVA: 0x0084B9B7 File Offset: 0x00849DB7
	protected override void UpdateControlState()
	{
		this.UpdateButton();
	}

	// Token: 0x0601AF71 RID: 110449 RVA: 0x0084B9BF File Offset: 0x00849DBF
	protected override void DoActionBeforeEndOfFrame()
	{
		this.axis.DoGravity();
	}

	// Token: 0x0601AF72 RID: 110450 RVA: 0x0084B9CC File Offset: 0x00849DCC
	public void SetDark(bool bActive, float alpha = 1f)
	{
		if (this.componentGray == null && this.fgImage != null)
		{
			this.componentGray = this.fgImage.gameObject.AddComponent<UIGray>();
		}
		if (this.componentGray == null)
		{
			return;
		}
		if (bActive)
		{
		}
		if (this.componentGray.enabled == bActive)
		{
			return;
		}
		this.componentGray.enabled = bActive;
	}

	// Token: 0x0601AF73 RID: 110451 RVA: 0x0084BA47 File Offset: 0x00849E47
	public void StartCoolDown(float time)
	{
		this.fCoolTime = time;
		this.fCoolTimeRate = 0f;
		this.bCoolDown = true;
		this.onCoolDownStart.Invoke();
	}

	// Token: 0x0601AF74 RID: 110452 RVA: 0x0084BA6D File Offset: 0x00849E6D
	public void StopCoolDown2()
	{
		this.bCoolDown = false;
	}

	// Token: 0x0601AF75 RID: 110453 RVA: 0x0084BA76 File Offset: 0x00849E76
	public void StopCoolDown()
	{
		this.fCoolTimeRate = 0.99f;
		this.bCoolDown = true;
	}

	// Token: 0x0601AF76 RID: 110454 RVA: 0x0084BA8A File Offset: 0x00849E8A
	public void Clear()
	{
	}

	// Token: 0x0601AF77 RID: 110455 RVA: 0x0084BA8C File Offset: 0x00849E8C
	public void SetFgImage(string spritePath, bool isMustExist = true)
	{
		ETCImageLoader.LoadSprite(ref this.fgImage, spritePath, isMustExist);
	}

	// Token: 0x0601AF78 RID: 110456 RVA: 0x0084BA9C File Offset: 0x00849E9C
	public void SetFgImageScale(float scale = 1f)
	{
		if (this.fgImage != null)
		{
			this.fgImage.transform.localScale = new Vector3(scale, scale, scale);
		}
	}

	// Token: 0x0601AF79 RID: 110457 RVA: 0x0084BAC8 File Offset: 0x00849EC8
	public void UpdateFakeCoolDown(int totoalTime, int sumTime, bool isBuffSkill)
	{
		this.UpdateBuffCD();
		this.mTotoalFakeCDTime = sumTime;
		if (totoalTime >= this.mTotoalFakeCDTime)
		{
			this.StopFakeCoolDown(isBuffSkill);
		}
		else
		{
			if (!this.bCoolDown)
			{
				this.bCoolDown = true;
				this.SetDark(true, 1f);
			}
			Image image = this.coolDownImage;
			if (image == null)
			{
				image = this.cachedImage;
			}
			if (this.coolDownImage != null)
			{
				this.coolDownImage.color = this.coolDownColor;
			}
			if (image != null)
			{
				image.fillAmount = 1f - (float)totoalTime * 1f / (float)this.mTotoalFakeCDTime;
			}
			if (this.fgCoolDownText != null)
			{
				this.fgCoolDownText.enabled = true;
				float rate = (float)(this.mTotoalFakeCDTime - totoalTime) / 1000f;
				this.RefreshCDText(rate);
			}
		}
	}

	// Token: 0x0601AF7A RID: 110458 RVA: 0x0084BBB0 File Offset: 0x00849FB0
	private void RefreshCDText(float rate)
	{
		if (Global.Settings.isDebug)
		{
			this.fgCoolDownText.text = rate.ToString("f1");
			return;
		}
		rate += 0.005f;
		if (rate > 1f)
		{
			int key = (int)rate;
			if (ETCButton.m_CDTextDic.ContainsKey(key))
			{
				this.fgCoolDownText.text = ETCButton.m_CDTextDic[key];
			}
			else
			{
				string text = key.ToString();
				ETCButton.m_CDTextDic.Add(key, text);
				this.fgCoolDownText.text = text;
			}
		}
		else
		{
			int num = (int)(rate * 10f);
			if (num < 10)
			{
				this.fgCoolDownText.text = ETCButton.m_CDMap[num];
			}
		}
	}

	// Token: 0x0601AF7B RID: 110459 RVA: 0x0084BC74 File Offset: 0x0084A074
	private float _getEffectSize()
	{
		Rect rect = this.normalSprite.rect;
		float num = rect.width / rect.height;
		float result;
		if (num >= 1f)
		{
			result = this.rectTransform().rect.width;
		}
		else
		{
			result = this.rectTransform().rect.height;
		}
		return result;
	}

	// Token: 0x0601AF7C RID: 110460 RVA: 0x0084BCE0 File Offset: 0x0084A0E0
	private void _loadEffect(ETCButton.eEffectType type, string path, bool needscale)
	{
		for (int i = 0; i < this.mCacheEffectObject.Count; i++)
		{
			if (this.mCacheEffectObject[i].type == type)
			{
				return;
			}
		}
		GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject(path, enResourceType.UIPrefab, 2U);
		Utility.AttachTo(gameObject, base.gameObject, false);
		this.mCacheEffectObject.Add(new ETCButton.CacheObject(type, gameObject));
		if (needscale)
		{
			float num = this._getEffectSize();
			Vector3 vector = Vector3.one / 300f * num;
		}
	}

	// Token: 0x0601AF7D RID: 110461 RVA: 0x0084BD74 File Offset: 0x0084A174
	public void StartBuffCD(BeBuff buff)
	{
		if (this.isBuffCD)
		{
			return;
		}
		this.goBuffBg.SetActive(true);
		this.goBuff.SetActive(true);
		this.imgBuff.fillAmount = 1f;
		this.buff = buff;
		this.isBuffCD = true;
	}

	// Token: 0x0601AF7E RID: 110462 RVA: 0x0084BDC4 File Offset: 0x0084A1C4
	public void UpdateBuffCD()
	{
		if (this.isBuffCD && this.buff != null)
		{
			this.imgBuff.fillAmount = 1f - this.buff.GetProcess();
			if (this.imgBuff.fillAmount <= 0f)
			{
				this.StopBuffCD();
			}
		}
	}

	// Token: 0x0601AF7F RID: 110463 RVA: 0x0084BE1E File Offset: 0x0084A21E
	public void StopBuffCD()
	{
		if (!this.isBuffCD)
		{
			return;
		}
		this.goBuffBg.SetActive(false);
		this.goBuff.SetActive(false);
		this.buff = null;
		this.isBuffCD = false;
	}

	// Token: 0x0601AF80 RID: 110464 RVA: 0x0084BE54 File Offset: 0x0084A254
	public void AddEffect(ETCButton.eEffectType type, bool isBuff = false)
	{
		if ((type == ETCButton.eEffectType.onBreak || type == ETCButton.eEffectType.onContinue) && isBuff)
		{
			type = ETCButton.eEffectType.onSkillBuff;
		}
		switch (type)
		{
		case ETCButton.eEffectType.onClick:
			this._loadEffect(type, "Effects/Scene_effects/EffectUI/EffUI_dianjifankui01", true);
			break;
		case ETCButton.eEffectType.onCDFinish:
			this._loadEffect(type, "Effects/Scene_effects/EffectUI/EffUI_cd_end", true);
			break;
		case ETCButton.eEffectType.onCDFinishBuff:
			this._loadEffect(type, "Effects/Scene_effects/EffectUI/EffUI_cd_end_buff", true);
			break;
		case ETCButton.eEffectType.onContinue:
			this._loadEffect(type, "Effects/Scene_effects/EffectUI/EffUI_Autoskill_hong_guo", true);
			break;
		case ETCButton.eEffectType.onBreak:
			this._loadEffect(type, "Effects/Scene_effects/EffectUI/EffUI_Autoskill_hong_guo", true);
			break;
		case ETCButton.eEffectType.onCharge:
			this._loadEffect(type, "UIFlatten/Prefabs/BattleUI/DungeonButtonStateCharge", false);
			break;
		case ETCButton.eEffectType.onSkillBuff:
			this._loadEffect(type, "Effects/Scene_effects/EffectUI/EffUI_Autoskill_chixu", false);
			break;
		case ETCButton.eEffectType.onSummonAccompy:
			this._loadEffect(type, "Effects/Scene_effects/EffectUI/EffUI_Autoskill_chixu_guo", false);
			break;
		case ETCButton.eEffectType.onSlide:
			this._loadEffect(type, "UIFlatten/Prefabs/BattleUI/DungeonButtonStateSlide", false);
			break;
		case ETCButton.eEffectType.onNew:
			this._loadEffect(type, "UIFlatten/Prefabs/Skill/SkillNewEffect", true);
			break;
		}
	}

	// Token: 0x0601AF81 RID: 110465 RVA: 0x0084BF64 File Offset: 0x0084A364
	public void RemoveEffect(ETCButton.eEffectType type, bool isBuff = false)
	{
		if ((type == ETCButton.eEffectType.onBreak || type == ETCButton.eEffectType.onContinue) && isBuff)
		{
			type = ETCButton.eEffectType.onSkillBuff;
		}
		bool flag = false;
		for (int i = 0; i < this.mCacheEffectObject.Count; i++)
		{
			if (this.mCacheEffectObject[i].type == type)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			this.mCacheEffectObject.RemoveAll(delegate(ETCButton.CacheObject x)
			{
				if (x.type == type)
				{
					Singleton<CGameObjectPool>.instance.RecycleGameObject(x.gameObject);
					return true;
				}
				return false;
			});
		}
	}

	// Token: 0x0601AF82 RID: 110466 RVA: 0x0084C004 File Offset: 0x0084A404
	public void StopFakeCoolDown(bool isBuffSkill = false)
	{
		if (null != this.fgImage)
		{
			this.fgImage.color = this.fgColor;
		}
		if (null != this.coolDownImage)
		{
			this.coolDownImage.color = Color.clear;
		}
		if (null != this.fgCoolDownText)
		{
			this.fgCoolDownText.enabled = false;
		}
		if (this.bCoolDown)
		{
			this.bCoolDown = false;
			ETCButton.eEffectType type = (!isBuffSkill) ? ETCButton.eEffectType.onCDFinish : ETCButton.eEffectType.onCDFinishBuff;
			this.RemoveEffect(type, false);
			this.AddEffect(type, false);
			if (this.onCoolDownEnd != null)
			{
				this.onCoolDownEnd.Invoke();
			}
			this.SetDark(false, 1f);
		}
	}

	// Token: 0x0601AF83 RID: 110467 RVA: 0x0084C0C4 File Offset: 0x0084A4C4
	private void UpdateCoolDown()
	{
		Image image = this.coolDownImage;
		if (image == null)
		{
			image = this.cachedImage;
		}
		if (this.bCoolDown)
		{
			this.fCoolTimeRate += (float)((int)(Time.deltaTime * 1000f)) / 1000f / this.fCoolTime;
			if (this.fCoolTimeRate >= 1f)
			{
				this.onCoolDownStep.Invoke(1f);
				image.fillAmount = 0f;
				this.onCoolDownEnd.Invoke();
				this.fgImage.color = this.fgColor;
				this.coolDownImage.color = Color.clear;
				this.fCoolTime = 0f;
				this.bCoolDown = false;
			}
			else
			{
				this.fgImage.color = this.fgCoolDownColor;
				this.coolDownImage.color = this.coolDownColor;
				image.fillAmount = 1f - this.fCoolTimeRate;
				this.onCoolDownStep.Invoke(this.fCoolTimeRate);
			}
		}
		else
		{
			this.fgImage.color = this.fgColor;
			this.coolDownImage.color = Color.clear;
		}
	}

	// Token: 0x0601AF84 RID: 110468 RVA: 0x0084C1F8 File Offset: 0x0084A5F8
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this.isSwipeIn && !this.isOnTouch)
		{
			if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<ETCBase>() && eventData.pointerDrag != base.gameObject)
			{
				this.previousDargObject = eventData.pointerDrag;
			}
			eventData.pointerDrag = base.gameObject;
			eventData.pointerPress = base.gameObject;
			this.OnPointerDown(eventData);
		}
	}

	// Token: 0x0601AF85 RID: 110469 RVA: 0x0084C284 File Offset: 0x0084A684
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this._activated && !this.isOnTouch)
		{
			this.pointId = eventData.pointerId;
			this.axis.ResetAxis();
			this.axis.axisState = ETCAxis.AxisState.Down;
			this.isOnPress = false;
			this.isOnTouch = true;
			this.RemoveEffect(ETCButton.eEffectType.onClick, false);
			this.AddEffect(ETCButton.eEffectType.onClick, false);
			this.RemoveEffect(ETCButton.eEffectType.onNew, false);
			this.onDown.Invoke();
			this.ApllyState();
			this.axis.UpdateButton();
			if (ComDrugTipsBar.instance != null)
			{
				ComDrugTipsBar.instance.SetDrugColumnStat();
			}
		}
	}

	// Token: 0x0601AF86 RID: 110470 RVA: 0x0084C328 File Offset: 0x0084A728
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
			if (!this._activated)
			{
				return;
			}
			if (this.axis.axisState == ETCAxis.AxisState.PressDown || this.axis.axisState == ETCAxis.AxisState.PressUp)
			{
				this.axis.axisState = ETCAxis.AxisState.None;
				this.ApllyState();
				return;
			}
			this.isOnPress = false;
			this.isOnTouch = false;
			this.axis.axisState = ETCAxis.AxisState.Up;
			this.axis.axisValue = 0f;
			this.onUp.Invoke();
			this.ApllyState();
			if (this.previousDargObject)
			{
				ExecuteEvents.Execute<IPointerUpHandler>(this.previousDargObject, eventData, ExecuteEvents.pointerUpHandler);
				this.previousDargObject = null;
			}
		}
	}

	// Token: 0x0601AF87 RID: 110471 RVA: 0x0084C3EC File Offset: 0x0084A7EC
	public void OnPointerExit(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId && this.axis.axisState == ETCAxis.AxisState.Press && !this.isSwipeOut)
		{
			this.OnPointerUp(eventData);
		}
	}

	// Token: 0x0601AF88 RID: 110472 RVA: 0x0084C424 File Offset: 0x0084A824
	private void UpdateButton()
	{
		if (this.axis.axisState == ETCAxis.AxisState.Down)
		{
			this.isOnPress = true;
			this.axis.axisState = ETCAxis.AxisState.Press;
		}
		if (this.isOnPress)
		{
			this.axis.UpdateButton();
			this.onPressed.Invoke();
			this.onPressedValue.Invoke(this.axis.axisValue);
		}
		if (this.axis.axisState == ETCAxis.AxisState.Up)
		{
			this.isOnPress = false;
			this.axis.axisState = ETCAxis.AxisState.None;
		}
		if (this.enableKeySimulation && this._activated && this._visible && !this.isOnTouch)
		{
			if (Input.GetButton(this.axis.unityAxis) && this.axis.axisState == ETCAxis.AxisState.None)
			{
				this.axis.ResetAxis();
				this.onDown.Invoke();
				this.axis.axisState = ETCAxis.AxisState.Down;
			}
			if (!Input.GetButton(this.axis.unityAxis) && this.axis.axisState == ETCAxis.AxisState.Press)
			{
				this.axis.axisState = ETCAxis.AxisState.Up;
				this.axis.axisValue = 0f;
				this.onUp.Invoke();
			}
			this.axis.UpdateButton();
			this.ApllyState();
		}
	}

	// Token: 0x0601AF89 RID: 110473 RVA: 0x0084C584 File Offset: 0x0084A984
	protected override void SetVisible(bool forceUnvisible = false)
	{
		bool visible = this._visible;
		if (!base.visible)
		{
			visible = base.visible;
		}
		base.GetComponent<Image>().enabled = visible;
	}

	// Token: 0x0601AF8A RID: 110474 RVA: 0x0084C5B8 File Offset: 0x0084A9B8
	private void ApllyState()
	{
		Color color;
		if (this.bDark)
		{
			color = this.normalColor;
		}
		else
		{
			color = this.normalDisableColor;
		}
		if (this.cachedImage)
		{
			ETCAxis.AxisState axisState = this.axis.axisState;
			if (axisState != ETCAxis.AxisState.Down && axisState != ETCAxis.AxisState.Press)
			{
				this.cachedImage.sprite = this.normalSprite;
				this.cachedImage.color = color;
			}
			else
			{
				this.cachedImage.sprite = this.pressedSprite;
				this.cachedImage.color = this.pressedColor;
			}
		}
	}

	// Token: 0x0601AF8B RID: 110475 RVA: 0x0084C65B File Offset: 0x0084AA5B
	protected override void SetActivated()
	{
		if (!this._activated)
		{
			this.isOnPress = false;
			this.isOnTouch = false;
			this.axis.axisState = ETCAxis.AxisState.None;
			this.axis.axisValue = 0f;
		}
		this.ApllyState();
	}

	// Token: 0x0601AF8C RID: 110476 RVA: 0x0084C698 File Offset: 0x0084AA98
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
		}
	}

	// Token: 0x170022C0 RID: 8896
	// (get) Token: 0x0601AF8D RID: 110477 RVA: 0x0084C6AB File Offset: 0x0084AAAB
	// (set) Token: 0x0601AF8E RID: 110478 RVA: 0x0084C6B3 File Offset: 0x0084AAB3
	public float dragOutLen
	{
		get
		{
			return this.mDragOutLen;
		}
		set
		{
			this.mDragOutLen = value;
		}
	}

	// Token: 0x0601AF8F RID: 110479 RVA: 0x0084C6BC File Offset: 0x0084AABC
	public void OnDrag(PointerEventData eventData)
	{
		if (this.isSwipeOut && this.pointId == eventData.pointerId && this.axis.axisState == ETCAxis.AxisState.Press)
		{
			Vector2 vector = this.cachedRectTransform.position;
			Vector2 vector2 = (eventData.position - vector) / this.cachedRootCanvas.rectTransform().localScale.x;
			Vector2 down = Vector2.down;
			ETCButton.DragDivMode dragDivMode = this.dragMode;
			if (dragDivMode != ETCButton.DragDivMode.ToCorner)
			{
				if (dragDivMode != ETCButton.DragDivMode.UpDown)
				{
					Logger.LogErrorFormat("undefine the drag mode {0}", new object[]
					{
						this.dragMode
					});
				}
				else
				{
					down = Vector2.down;
				}
			}
			else
			{
				down..ctor(base.anchorOffet.x, -base.anchorOffet.y);
			}
			float magnitude = vector2.magnitude;
		}
	}

	// Token: 0x04012CD8 RID: 77016
	private UIGray componentGray;

	// Token: 0x04012CD9 RID: 77017
	[SerializeField]
	public ETCButton.OnDownHandler onDown;

	// Token: 0x04012CDA RID: 77018
	[SerializeField]
	public ETCButton.OnPressedHandler onPressed;

	// Token: 0x04012CDB RID: 77019
	[SerializeField]
	public ETCButton.OnPressedValueandler onPressedValue;

	// Token: 0x04012CDC RID: 77020
	[SerializeField]
	public ETCButton.OnUPHandler onUp;

	// Token: 0x04012CDD RID: 77021
	[SerializeField]
	public ETCButton.OnCoolDownStartHandler onCoolDownStart;

	// Token: 0x04012CDE RID: 77022
	[SerializeField]
	public ETCButton.OnCoolDownEndHandler onCoolDownEnd;

	// Token: 0x04012CDF RID: 77023
	[SerializeField]
	public ETCButton.OnCoolDownStepHandler onCoolDownStep;

	// Token: 0x04012CE0 RID: 77024
	[SerializeField]
	public ETCButton.OnDragOutUpHandler onDragOutUp;

	// Token: 0x04012CE1 RID: 77025
	[SerializeField]
	public ETCButton.OnDragOutDownHandler onDragOutDown;

	// Token: 0x04012CE2 RID: 77026
	public ETCAxis axis;

	// Token: 0x04012CE3 RID: 77027
	public Sprite normalSprite;

	// Token: 0x04012CE4 RID: 77028
	public Color normalColor;

	// Token: 0x04012CE5 RID: 77029
	public Color normalDisableColor;

	// Token: 0x04012CE6 RID: 77030
	public Sprite pressedSprite;

	// Token: 0x04012CE7 RID: 77031
	public Color pressedColor;

	// Token: 0x04012CE8 RID: 77032
	public Sprite coolDownSprite;

	// Token: 0x04012CE9 RID: 77033
	public Color coolDownColor;

	// Token: 0x04012CEA RID: 77034
	public Image coolDownImage;

	// Token: 0x04012CEB RID: 77035
	public RectTransform coolDownRect;

	// Token: 0x04012CEC RID: 77036
	public Sprite fgSprite;

	// Token: 0x04012CED RID: 77037
	public Color fgColor;

	// Token: 0x04012CEE RID: 77038
	public Color fgCoolDownColor;

	// Token: 0x04012CEF RID: 77039
	public Text fgCoolDownText;

	// Token: 0x04012CF0 RID: 77040
	public Image fgImage;

	// Token: 0x04012CF1 RID: 77041
	public RectTransform fgRect;

	// Token: 0x04012CF2 RID: 77042
	public Image imgBuffBg;

	// Token: 0x04012CF3 RID: 77043
	public Image imgBuff;

	// Token: 0x04012CF4 RID: 77044
	public GameObject goBuffBg;

	// Token: 0x04012CF5 RID: 77045
	public GameObject goBuff;

	// Token: 0x04012CF6 RID: 77046
	private BeBuff buff;

	// Token: 0x04012CF7 RID: 77047
	private bool isBuffCD;

	// Token: 0x04012CF8 RID: 77048
	private Image cachedImage;

	// Token: 0x04012CF9 RID: 77049
	private bool isOnPress;

	// Token: 0x04012CFA RID: 77050
	private GameObject previousDargObject;

	// Token: 0x04012CFB RID: 77051
	private bool isOnTouch;

	// Token: 0x04012CFC RID: 77052
	private bool bDark = true;

	// Token: 0x04012CFD RID: 77053
	private float fCoolTime;

	// Token: 0x04012CFE RID: 77054
	private float fCoolTimeRate;

	// Token: 0x04012CFF RID: 77055
	private bool bCoolDown;

	// Token: 0x04012D00 RID: 77056
	private int mTotoalFakeCDTime;

	// Token: 0x04012D01 RID: 77057
	private static string[] m_CDMap = new string[]
	{
		"0.0",
		"0.1",
		"0.2",
		"0.3",
		"0.4",
		"0.5",
		"0.6",
		"0.7",
		"0.8",
		"0.9"
	};

	// Token: 0x04012D02 RID: 77058
	private static Dictionary<int, string> m_CDTextDic = new Dictionary<int, string>();

	// Token: 0x04012D03 RID: 77059
	private List<ETCButton.CacheObject> mCacheEffectObject = new List<ETCButton.CacheObject>();

	// Token: 0x04012D04 RID: 77060
	private float mDragOutLen = 120f;

	// Token: 0x04012D05 RID: 77061
	public ETCButton.DragDivMode dragMode = ETCButton.DragDivMode.ToCorner;

	// Token: 0x02004944 RID: 18756
	[Serializable]
	public class OnDownHandler : UnityEvent
	{
	}

	// Token: 0x02004945 RID: 18757
	[Serializable]
	public class OnPressedHandler : UnityEvent
	{
	}

	// Token: 0x02004946 RID: 18758
	[Serializable]
	public class OnPressedValueandler : UnityEvent<float>
	{
	}

	// Token: 0x02004947 RID: 18759
	[Serializable]
	public class OnUPHandler : UnityEvent
	{
	}

	// Token: 0x02004948 RID: 18760
	[Serializable]
	public class OnCoolDownStartHandler : UnityEvent
	{
	}

	// Token: 0x02004949 RID: 18761
	[Serializable]
	public class OnCoolDownEndHandler : UnityEvent
	{
	}

	// Token: 0x0200494A RID: 18762
	[Serializable]
	public class OnCoolDownStepHandler : UnityEvent<float>
	{
	}

	// Token: 0x0200494B RID: 18763
	[Serializable]
	public class OnDragOutUpHandler : UnityEvent
	{
	}

	// Token: 0x0200494C RID: 18764
	[Serializable]
	public class OnDragOutDownHandler : UnityEvent
	{
	}

	// Token: 0x0200494D RID: 18765
	public enum eEffectType
	{
		// Token: 0x04012D07 RID: 77063
		onClick,
		// Token: 0x04012D08 RID: 77064
		onCDFinish,
		// Token: 0x04012D09 RID: 77065
		onCDFinishBuff,
		// Token: 0x04012D0A RID: 77066
		onContinue,
		// Token: 0x04012D0B RID: 77067
		onBreak,
		// Token: 0x04012D0C RID: 77068
		onCharge,
		// Token: 0x04012D0D RID: 77069
		onSkillBuff,
		// Token: 0x04012D0E RID: 77070
		onSummonAccompy,
		// Token: 0x04012D0F RID: 77071
		onSlide,
		// Token: 0x04012D10 RID: 77072
		onNew
	}

	// Token: 0x0200494E RID: 18766
	private class CacheObject
	{
		// Token: 0x0601AF9A RID: 110490 RVA: 0x0084C874 File Offset: 0x0084AC74
		public CacheObject(ETCButton.eEffectType t, GameObject go)
		{
			this.gameObject = go;
			this.type = t;
		}

		// Token: 0x170022C1 RID: 8897
		// (get) Token: 0x0601AF9B RID: 110491 RVA: 0x0084C88A File Offset: 0x0084AC8A
		// (set) Token: 0x0601AF9C RID: 110492 RVA: 0x0084C892 File Offset: 0x0084AC92
		public GameObject gameObject { get; private set; }

		// Token: 0x170022C2 RID: 8898
		// (get) Token: 0x0601AF9D RID: 110493 RVA: 0x0084C89B File Offset: 0x0084AC9B
		// (set) Token: 0x0601AF9E RID: 110494 RVA: 0x0084C8A3 File Offset: 0x0084ACA3
		public ETCButton.eEffectType type { get; private set; }
	}

	// Token: 0x0200494F RID: 18767
	public enum DragDivMode
	{
		// Token: 0x04012D14 RID: 77076
		UpDown,
		// Token: 0x04012D15 RID: 77077
		ToCorner
	}
}
