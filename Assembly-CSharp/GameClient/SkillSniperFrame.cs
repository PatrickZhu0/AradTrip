using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010E1 RID: 4321
	public class SkillSniperFrame : ClientFrame
	{
		// Token: 0x0600A38D RID: 41869 RVA: 0x00218290 File Offset: 0x00216690
		protected override void _bindExUI()
		{
			this.mTarget = this.mBind.GetCom<RectTransform>("Target");
			this.mMaskMaterial = this.mBind.GetCom<Image>("maskMaterial");
			this.mBullteContainer = this.mBind.GetCom<RectTransform>("BullteContainer");
			this.mShotEffect = this.mBind.GetCom<RectTransform>("ShotEffect");
			this.mZidanTemp = this.mBind.GetCom<Toggle>("ZidanTemp");
			this.mFireAni = this.mBind.GetCom<DOTweenAnimation>("FireAni");
			this.mCloseAni = this.mBind.GetCom<DOTweenAnimation>("CloseAni");
			this.mDakeAni = this.mBind.GetCom<DOTweenAnimation>("DakeAni");
			this.mCdDi = this.mBind.GetCom<RectTransform>("CdDi");
			this.mCdSlider = this.mBind.GetCom<RectTransform>("CdSlider");
			this.mSkillTime = this.mBind.GetCom<Text>("SkillTime");
			this.mZidanCanvas = this.mBind.GetCom<CanvasGroup>("ZidanCanvas");
			this.mCdDiCanvas = this.mBind.GetCom<CanvasGroup>("CdDiCanvas");
			this.mCDSliderCanvas = this.mBind.GetCom<CanvasGroup>("CDSliderCanvas");
			this.mSkillTimeCanvas = this.mBind.GetCom<CanvasGroup>("SkillTimeCanvas");
			this.mImageDiCanvas = this.mBind.GetCom<CanvasGroup>("ImageDiCanvas");
			this.mCDSlider1 = this.mBind.GetCom<Image>("CDSlider1");
			this.mCDSlider2 = this.mBind.GetCom<Image>("CDSlider2");
			this.mCDSlider3 = this.mBind.GetCom<Image>("CDSlider3");
			this.mCDSlider4 = this.mBind.GetCom<Image>("CDSlider4");
			this.mCDSlider5 = this.mBind.GetCom<Image>("CDSlider5");
			this.mCDSlider6 = this.mBind.GetCom<Image>("CDSlider6");
			this.mCDSlider7 = this.mBind.GetCom<Image>("CDSlider7");
			this.mCDSlider8 = this.mBind.GetCom<Image>("CDSlider8");
			this.mCDSlider9 = this.mBind.GetCom<Image>("CDSlider9");
			this.mCDSlider10 = this.mBind.GetCom<Image>("CDSlider10");
		}

		// Token: 0x0600A38E RID: 41870 RVA: 0x002184DC File Offset: 0x002168DC
		protected override void _unbindExUI()
		{
			this.mTarget = null;
			this.mMaskMaterial = null;
			this.mBullteContainer = null;
			this.mShotEffect = null;
			this.mZidanTemp = null;
			this.mFireAni = null;
			this.mCloseAni = null;
			this.mDakeAni = null;
			this.mCdDi = null;
			this.mCdSlider = null;
			this.mSkillTime = null;
			this.mZidanCanvas = null;
			this.mCdDiCanvas = null;
			this.mCDSliderCanvas = null;
			this.mSkillTimeCanvas = null;
			this.mImageDiCanvas = null;
			this.mCDSlider1 = null;
			this.mCDSlider2 = null;
			this.mCDSlider3 = null;
			this.mCDSlider4 = null;
			this.mCDSlider5 = null;
			this.mCDSlider6 = null;
			this.mCDSlider7 = null;
			this.mCDSlider8 = null;
			this.mCDSlider9 = null;
			this.mCDSlider10 = null;
		}

		// Token: 0x0600A38F RID: 41871 RVA: 0x0021859F File Offset: 0x0021699F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/SkillSniperFrame";
		}

		// Token: 0x0600A390 RID: 41872 RVA: 0x002185A8 File Offset: 0x002169A8
		protected override void _OnOpenFrame()
		{
			this.InitData();
			this.targetPos = this.mTarget.localPosition;
			this.cameraOriginPos = BattleMain.instance.Main.currentGeScene.GetCamera().GetController().transform.localPosition;
		}

		// Token: 0x0600A391 RID: 41873 RVA: 0x002185F5 File Offset: 0x002169F5
		public void InitCenterPos()
		{
			this.m_CenterOriginalPos = this.GetCenterScenePos(Vector3.zero);
		}

		// Token: 0x0600A392 RID: 41874 RVA: 0x00218608 File Offset: 0x00216A08
		protected override void _OnUpdate(float timeElapsed)
		{
			base._OnUpdate(timeElapsed);
		}

		// Token: 0x0600A393 RID: 41875 RVA: 0x00218611 File Offset: 0x00216A11
		protected override void _OnCloseFrame()
		{
			this.InitData();
		}

		// Token: 0x0600A394 RID: 41876 RVA: 0x0021861C File Offset: 0x00216A1C
		protected void InitData()
		{
			this.mCdDi.gameObject.CustomActive(true);
			this.mCdSlider.gameObject.CustomActive(true);
			this.mZidanList.Clear();
			if (this.mMaskMaterial != null)
			{
				this.mMaskMaterial.material.SetTextureOffset("_Mask", Vector2.zero);
				this.mMaskMaterial.material.SetColor("_Alpha", new Color(1f, 1f, 1f, 0f));
			}
			if (this.mImageDiCanvas != null)
			{
				this.mImageDiCanvas.alpha = 1f;
			}
		}

		// Token: 0x0600A395 RID: 41877 RVA: 0x002186D0 File Offset: 0x00216AD0
		public void Attack(int curNum)
		{
			this.PlayAttackEffect(curNum);
			this.SetZiDanUsed(curNum, true);
		}

		// Token: 0x0600A396 RID: 41878 RVA: 0x002186E4 File Offset: 0x00216AE4
		public void _OnJoyStickMove(Vector2 offset)
		{
			bool flag = (this.GetCenterMoveDis() > this.m_MoveXOffset && !this.IsXMoveLeft(offset)) || (this.GetCenterMoveDis() < -this.m_MoveXOffset && this.IsXMoveLeft(offset));
			if (flag)
			{
				return;
			}
			bool flag2 = BattleMain.instance.Main.currentGeScene.GetCamera().GetController().IsInSceneLeftEdge();
			bool flag3 = BattleMain.instance.Main.currentGeScene.GetCamera().GetController().IsInSceneRightEdge();
			int num = (!flag2 && !flag3) ? 400 : 1920;
			if (offset.x != 0f)
			{
				if (!flag2 && !flag3)
				{
					if (this.targetPos.x < (float)(-(float)num / 2) || this.targetPos.x > (float)(num / 2))
					{
						this.CameraMove(offset);
					}
					else if (this.targetPos.x == (float)(-(float)num / 2))
					{
						if (this.IsXMoveLeft(offset))
						{
							this.CameraMove(offset);
						}
						else
						{
							this.GunMove(offset.x, 0f, num);
						}
					}
					else if (this.targetPos.x == (float)(num / 2))
					{
						if (this.IsXMoveLeft(offset))
						{
							this.GunMove(offset.x, 0f, num);
						}
						else
						{
							this.CameraMove(offset);
						}
					}
					else
					{
						this.GunMove(offset.x, 0f, num);
					}
				}
				else
				{
					if (flag2)
					{
						if (this.IsXMoveLeft(offset))
						{
							this.GunMove(offset.x, 0f, num);
						}
						else if (this.targetPos.x >= 0f)
						{
							this.CameraMove(offset);
						}
						else
						{
							this.GunMove(offset.x, 0f, num);
						}
					}
					if (flag3)
					{
						if (this.IsXMoveLeft(offset))
						{
							if (this.targetPos.x <= 0f)
							{
								this.CameraMove(offset);
							}
							else
							{
								this.GunMove(offset.x, 0f, num);
							}
						}
						else
						{
							this.GunMove(offset.x, 0f, num);
						}
					}
				}
			}
			if (offset.y != 0f)
			{
				this.GunMove(0f, offset.y, num);
			}
			this.UpdateUIAlpha();
		}

		// Token: 0x0600A397 RID: 41879 RVA: 0x00218968 File Offset: 0x00216D68
		protected bool IsXMoveLeft(Vector2 offset)
		{
			return offset.x < 0f;
		}

		// Token: 0x0600A398 RID: 41880 RVA: 0x00218978 File Offset: 0x00216D78
		protected void GunMove(float xOffset, float yOffset, int moveOffsetX)
		{
			if (xOffset != 0f)
			{
				this.targetPos.x = this.targetPos.x + xOffset * this.targetMoveSpeed;
				this.targetPos.x = Mathf.Clamp(this.targetPos.x, (float)(-(float)moveOffsetX / 2), (float)(moveOffsetX / 2));
			}
			if (yOffset != 0f)
			{
				this.targetPos.y = this.targetPos.y + yOffset * this.targetMoveSpeed;
				this.targetPos.y = Mathf.Clamp(this.targetPos.y, -540f, 540f);
			}
			this.mTarget.localPosition = this.targetPos;
			this.v.x = -this.targetPos.x / 1920f;
			this.v.y = -this.targetPos.y / 1080f;
			this.mMaskMaterial.material.SetTextureOffset("_Mask", this.v);
		}

		// Token: 0x0600A399 RID: 41881 RVA: 0x00218A80 File Offset: 0x00216E80
		protected void CameraMove(Vector2 offset)
		{
			Vector3 localPosition = BattleMain.instance.Main.currentGeScene.GetCamera().GetController().transform.localPosition;
			localPosition.x += offset.x * this.cameraMoveSpeed;
			BattleMain.instance.Main.currentGeScene.GetCamera().GetController().SetCameraPos(localPosition);
		}

		// Token: 0x0600A39A RID: 41882 RVA: 0x00218AEC File Offset: 0x00216EEC
		protected void UpdateUIAlpha()
		{
			this.UpdateZidanAlpha();
			this.UpdateCDAlpha();
			this.UpdateSkillTimeAlpha();
		}

		// Token: 0x0600A39B RID: 41883 RVA: 0x00218B00 File Offset: 0x00216F00
		protected float GetCenterMoveDis()
		{
			return this.GetCenterScenePos(this.GetWorldCenterPoint()).x - this.m_CenterOriginalPos.x;
		}

		// Token: 0x0600A39C RID: 41884 RVA: 0x00218B30 File Offset: 0x00216F30
		public Vector3 GetCenterScenePos(Vector3 centerWorldPos)
		{
			Vector3 zero = Vector3.zero;
			Vector3 vector = Singleton<ClientSystemManager>.GetInstance().UICamera.WorldToScreenPoint(centerWorldPos);
			Ray ray = Camera.main.ScreenPointToRay(vector);
			float num = -ray.origin.y / ray.direction.y;
			return new Vector3(ray.origin.x + num * ray.direction.x, 0f, ray.origin.z + num * ray.direction.z);
		}

		// Token: 0x0600A39D RID: 41885 RVA: 0x00218BD3 File Offset: 0x00216FD3
		public Vector2 GetCenterPoint()
		{
			return this.mTarget.localPosition;
		}

		// Token: 0x0600A39E RID: 41886 RVA: 0x00218BE5 File Offset: 0x00216FE5
		public Vector3 GetWorldCenterPoint()
		{
			return this.mTarget.position;
		}

		// Token: 0x0600A39F RID: 41887 RVA: 0x00218BF2 File Offset: 0x00216FF2
		public RectTransform GetTargetParent()
		{
			return this.mTarget.parent as RectTransform;
		}

		// Token: 0x170019A3 RID: 6563
		// (get) Token: 0x0600A3A0 RID: 41888 RVA: 0x00218C04 File Offset: 0x00217004
		public GameObject gameObject
		{
			get
			{
				return this.frame;
			}
		}

		// Token: 0x0600A3A1 RID: 41889 RVA: 0x00218C0C File Offset: 0x0021700C
		public void RefreshProgress(float progress)
		{
			if (this.mCDSlider1 == null)
			{
				return;
			}
			float num = progress * 10f;
			int num2 = Mathf.CeilToInt(num);
			float fillAmount = (num - (float)num2) * 10f;
			this.mCDSlider1.fillAmount = (float)((num2 < 1) ? 0 : 1);
			this.mCDSlider2.fillAmount = (float)((num2 < 2) ? 0 : 1);
			this.mCDSlider3.fillAmount = (float)((num2 < 3) ? 0 : 1);
			this.mCDSlider4.fillAmount = (float)((num2 < 4) ? 0 : 1);
			this.mCDSlider5.fillAmount = (float)((num2 < 5) ? 0 : 1);
			this.mCDSlider6.fillAmount = (float)((num2 < 6) ? 0 : 1);
			this.mCDSlider7.fillAmount = (float)((num2 < 7) ? 0 : 1);
			this.mCDSlider8.fillAmount = (float)((num2 < 8) ? 0 : 1);
			this.mCDSlider9.fillAmount = (float)((num2 < 9) ? 0 : 1);
			this.mCDSlider10.fillAmount = (float)((num2 < 10) ? 0 : 1);
			switch (num2)
			{
			case 0:
				this.mCDSlider1.fillAmount = fillAmount;
				break;
			case 1:
				this.mCDSlider2.fillAmount = fillAmount;
				break;
			case 2:
				this.mCDSlider3.fillAmount = fillAmount;
				break;
			case 3:
				this.mCDSlider4.fillAmount = fillAmount;
				break;
			case 4:
				this.mCDSlider5.fillAmount = fillAmount;
				break;
			case 5:
				this.mCDSlider6.fillAmount = fillAmount;
				break;
			case 6:
				this.mCDSlider7.fillAmount = fillAmount;
				break;
			case 7:
				this.mCDSlider8.fillAmount = fillAmount;
				break;
			case 8:
				this.mCDSlider9.fillAmount = fillAmount;
				break;
			case 9:
				this.mCDSlider10.fillAmount = fillAmount;
				break;
			}
		}

		// Token: 0x0600A3A2 RID: 41890 RVA: 0x00218E28 File Offset: 0x00217228
		public void CloseProgress()
		{
			this.mCdDi.gameObject.CustomActive(false);
			this.mCdSlider.gameObject.CustomActive(false);
		}

		// Token: 0x0600A3A3 RID: 41891 RVA: 0x00218E4C File Offset: 0x0021724C
		protected void PlayAttackEffect(int curNum)
		{
			this.PlayFireAni();
			this.SetZiDanUsed(curNum, true);
			if (this.mShotEffect == null || Singleton<ClientSystemManager>.GetInstance() == null)
			{
				return;
			}
			this.mShotEffect.gameObject.CustomActive(true);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(300, delegate
			{
				if (this.mShotEffect != null)
				{
					this.mShotEffect.gameObject.CustomActive(false);
				}
			}, 0, 0, true);
		}

		// Token: 0x0600A3A4 RID: 41892 RVA: 0x00218EB8 File Offset: 0x002172B8
		public void InitZiDan(int maxBulletNum)
		{
			if (this.mSkillTime != null)
			{
				this.mSkillTime.CustomActive(true);
			}
			if (this.mZidanCanvas != null)
			{
				this.mZidanCanvas.gameObject.CustomActive(true);
			}
			for (int i = 0; i < maxBulletNum; i++)
			{
				this.CreateZiDan(i);
				this.SetZiDanUsed(i, false);
			}
		}

		// Token: 0x0600A3A5 RID: 41893 RVA: 0x00218F28 File Offset: 0x00217328
		protected void CreateZiDan(int index)
		{
			Toggle toggle = Object.Instantiate<Toggle>(this.mZidanTemp, this.mZidanTemp.transform.parent);
			toggle.name = index.ToString();
			toggle.CustomActive(true);
			this.mZidanList.Add(toggle);
		}

		// Token: 0x0600A3A6 RID: 41894 RVA: 0x00218F78 File Offset: 0x00217378
		public void ShowSkillTime(int time)
		{
			string text = ((float)time / 1000f).ToString("0");
			if (this.mSkillTime != null)
			{
				this.mSkillTime.text = text;
			}
		}

		// Token: 0x0600A3A7 RID: 41895 RVA: 0x00218FB8 File Offset: 0x002173B8
		protected void SetZiDanUsed(int index, bool used)
		{
			this.mZidanList[index].isOn = !used;
			if (this.mDakeAni != null)
			{
				this.mDakeAni.transform.position = this.mZidanList[index].transform.position;
				if (used)
				{
					this.mDakeAni.gameObject.CustomActive(true);
				}
				this.mDakeAni.DORestart(false);
			}
		}

		// Token: 0x0600A3A8 RID: 41896 RVA: 0x00219034 File Offset: 0x00217434
		protected void PlayFireAni()
		{
			MonoSingleton<AudioManager>.instance.PlaySound(3868);
			MonoSingleton<AudioManager>.instance.PlaySound(3870);
			if (this.mFireAni != null)
			{
				this.mFireAni.DORestartById("sheji");
			}
			if (this.mDakeAni != null)
			{
				this.mDakeAni.gameObject.CustomActive(true);
				this.mDakeAni.DORestartById("danke1");
				this.mDakeAni.DORestartById("danke2");
			}
		}

		// Token: 0x0600A3A9 RID: 41897 RVA: 0x002190C4 File Offset: 0x002174C4
		public void PlayCloseAni()
		{
			if (this.mCloseAni != null)
			{
				this.mCloseAni.DORestartById("xiaoshi");
			}
			TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To(() => 0f, delegate(float x)
			{
				if (this.mMaskMaterial != null)
				{
					this.mMaskMaterial.material.SetColor("_Alpha", new Color(1f, 1f, 1f, x));
				}
				if (this.mImageDiCanvas != null)
				{
					this.mImageDiCanvas.alpha = 1f - x;
				}
			}, 1f, 0.16f), 6);
			if (this.mSkillTime != null)
			{
				this.mSkillTime.CustomActive(false);
			}
			if (this.mZidanCanvas != null)
			{
				this.mZidanCanvas.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600A3AA RID: 41898 RVA: 0x00219170 File Offset: 0x00217570
		protected void UpdateZidanAlpha()
		{
			if (this.mZidanCanvas != null)
			{
				Vector2 centerPoint = this.GetCenterPoint();
				if (centerPoint.x > 320f && centerPoint.y < 460f)
				{
					if (this.mZidanCanvas.alpha == 1f)
					{
						this.mZidanCanvas.alpha = 0.4f;
					}
				}
				else if (this.mZidanCanvas.alpha == 0.4f)
				{
					this.mZidanCanvas.alpha = 1f;
				}
			}
		}

		// Token: 0x0600A3AB RID: 41899 RVA: 0x00219208 File Offset: 0x00217608
		protected void UpdateCDAlpha()
		{
			if (this.mCDSliderCanvas != null)
			{
				Vector2 centerPoint = this.GetCenterPoint();
				if ((centerPoint.x > -660f || centerPoint.x < 660f) && centerPoint.y < 0f)
				{
					if (this.mCDSliderCanvas.alpha == 1f)
					{
						this.mCDSliderCanvas.alpha = 0.4f;
					}
					if (this.mCdDiCanvas.alpha == 1f)
					{
						this.mCdDiCanvas.alpha = 0.4f;
					}
				}
				else
				{
					if (this.mCDSliderCanvas.alpha == 0.4f)
					{
						this.mCDSliderCanvas.alpha = 1f;
					}
					if (this.mCdDiCanvas.alpha == 0.4f)
					{
						this.mCdDiCanvas.alpha = 1f;
					}
				}
			}
		}

		// Token: 0x0600A3AC RID: 41900 RVA: 0x002192FC File Offset: 0x002176FC
		protected void UpdateSkillTimeAlpha()
		{
			if (this.mSkillTimeCanvas != null)
			{
				Vector2 centerPoint = this.GetCenterPoint();
				if (centerPoint.x > 140f && (centerPoint.y < 350f || centerPoint.y > -640f))
				{
					if (this.mSkillTimeCanvas.alpha == 1f)
					{
						this.mSkillTimeCanvas.alpha = 0.4f;
					}
				}
				else if (this.mSkillTimeCanvas.alpha == 0.4f)
				{
					this.mSkillTimeCanvas.alpha = 1f;
				}
			}
		}

		// Token: 0x04005B35 RID: 23349
		private RectTransform mTarget;

		// Token: 0x04005B36 RID: 23350
		private Image mMaskMaterial;

		// Token: 0x04005B37 RID: 23351
		private RectTransform mBullteContainer;

		// Token: 0x04005B38 RID: 23352
		private RectTransform mShotEffect;

		// Token: 0x04005B39 RID: 23353
		private Toggle mZidanTemp;

		// Token: 0x04005B3A RID: 23354
		private List<Toggle> mZidanList = new List<Toggle>();

		// Token: 0x04005B3B RID: 23355
		private DOTweenAnimation mFireAni;

		// Token: 0x04005B3C RID: 23356
		private DOTweenAnimation mCloseAni;

		// Token: 0x04005B3D RID: 23357
		private DOTweenAnimation mDakeAni;

		// Token: 0x04005B3E RID: 23358
		private RectTransform mCdDi;

		// Token: 0x04005B3F RID: 23359
		private RectTransform mCdSlider;

		// Token: 0x04005B40 RID: 23360
		private Text mSkillTime;

		// Token: 0x04005B41 RID: 23361
		private CanvasGroup mZidanCanvas;

		// Token: 0x04005B42 RID: 23362
		private CanvasGroup mCdDiCanvas;

		// Token: 0x04005B43 RID: 23363
		private CanvasGroup mCDSliderCanvas;

		// Token: 0x04005B44 RID: 23364
		private CanvasGroup mSkillTimeCanvas;

		// Token: 0x04005B45 RID: 23365
		private CanvasGroup mImageDiCanvas;

		// Token: 0x04005B46 RID: 23366
		private Image mCDSlider1;

		// Token: 0x04005B47 RID: 23367
		private Image mCDSlider2;

		// Token: 0x04005B48 RID: 23368
		private Image mCDSlider3;

		// Token: 0x04005B49 RID: 23369
		private Image mCDSlider4;

		// Token: 0x04005B4A RID: 23370
		private Image mCDSlider5;

		// Token: 0x04005B4B RID: 23371
		private Image mCDSlider6;

		// Token: 0x04005B4C RID: 23372
		private Image mCDSlider7;

		// Token: 0x04005B4D RID: 23373
		private Image mCDSlider8;

		// Token: 0x04005B4E RID: 23374
		private Image mCDSlider9;

		// Token: 0x04005B4F RID: 23375
		private Image mCDSlider10;

		// Token: 0x04005B50 RID: 23376
		public Vector3 targetPos;

		// Token: 0x04005B51 RID: 23377
		public float targetMoveSpeed = 22f;

		// Token: 0x04005B52 RID: 23378
		private Vector2 v = Vector2.zero;

		// Token: 0x04005B53 RID: 23379
		private Vector3 cameraOriginPos;

		// Token: 0x04005B54 RID: 23380
		public float cameraMoveSpeed = 0.15f;

		// Token: 0x04005B55 RID: 23381
		public float m_MoveXOffset = 20f;

		// Token: 0x04005B56 RID: 23382
		public BeActor m_Owner;

		// Token: 0x04005B57 RID: 23383
		protected Vector3 m_CenterOriginalPos = Vector3.zero;
	}
}
