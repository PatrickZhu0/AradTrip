using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010E3 RID: 4323
	public class SkillTargetFrame : ClientFrame
	{
		// Token: 0x0600A3BE RID: 41918 RVA: 0x00219648 File Offset: 0x00217A48
		protected override void _bindExUI()
		{
			this.target = this.mBind.GetCom<RectTransform>("Target");
			this.timeProgress = this.mBind.GetCom<Slider>("TimeProgress");
			this.bulluteProgress = this.mBind.GetCom<Image>("BulleteProgress");
			this.maskMaterial = this.mBind.GetCom<Image>("maskMaterial");
			this.BullteContainer = this.mBind.GetCom<Transform>("BullteContainer");
			this.danke = this.mBind.GetCom<Transform>("danke");
			this.fireAnim = this.mBind.GetCom<DOTweenAnimation>("Fire");
		}

		// Token: 0x0600A3BF RID: 41919 RVA: 0x002196EF File Offset: 0x00217AEF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/SkillTargetFrame";
		}

		// Token: 0x0600A3C0 RID: 41920 RVA: 0x002196F8 File Offset: 0x00217AF8
		protected override void _OnOpenFrame()
		{
			this.cameraOriginPos = BattleMain.instance.Main.currentGeScene.GetCamera().GetController().transform.localPosition;
			this.targetPos = this.target.localPosition;
			this.InitJoystick();
			this.maskMaterial.material.SetTextureOffset("_Mask", Vector2.zero);
			this.InitBullet();
		}

		// Token: 0x0600A3C1 RID: 41921 RVA: 0x00219768 File Offset: 0x00217B68
		private void InitBullet()
		{
			this.bulleteList.Clear();
			this.bullteContainerlist.Clear();
			for (int i = 0; i < this.BullteContainer.childCount; i++)
			{
				if (i <= 9)
				{
					this.bullteContainerlist.Add(this.BullteContainer.GetChild(i).gameObject);
				}
				else
				{
					this.bulleteList.Add(this.BullteContainer.GetChild(i).gameObject);
				}
			}
		}

		// Token: 0x0600A3C2 RID: 41922 RVA: 0x002197EC File Offset: 0x00217BEC
		private void InitJoystick()
		{
			InputManager.instance.SetJoyStickMoveEndCallback(new UnityAction(this._OnJoyStickStop));
			InputManager.instance.SetJoyStickMoveCallback(new UnityAction<Vector2>(this._OnJoyStickMove));
		}

		// Token: 0x170019A5 RID: 6565
		// (get) Token: 0x0600A3C3 RID: 41923 RVA: 0x0021981A File Offset: 0x00217C1A
		public GameObject gameObject
		{
			get
			{
				return this.frame;
			}
		}

		// Token: 0x0600A3C4 RID: 41924 RVA: 0x00219822 File Offset: 0x00217C22
		public Vector3 GetWorldCenterPoint()
		{
			return this.target.position;
		}

		// Token: 0x0600A3C5 RID: 41925 RVA: 0x0021982F File Offset: 0x00217C2F
		public Vector2 GetCenterPoint()
		{
			if (this.target == null)
			{
				return Vector2.zero;
			}
			return this.target.localPosition;
		}

		// Token: 0x0600A3C6 RID: 41926 RVA: 0x00219858 File Offset: 0x00217C58
		private void _OnJoyStickMove(Vector2 arg0)
		{
			this.targetPos.x = this.targetPos.x + arg0.x * this.targetMoveSpeed;
			this.targetPos.y = this.targetPos.y + arg0.y * this.targetMoveSpeed;
			this.targetPos.x = Mathf.Clamp(this.targetPos.x, -960f, 960f);
			this.targetPos.y = Mathf.Clamp(this.targetPos.y, -540f, 540f);
			this.target.localPosition = this.targetPos;
			this.v.x = -this.targetPos.x / 2340f;
			this.v.y = -this.targetPos.y / 1440f;
			this.maskMaterial.material.SetTextureOffset("_Mask", this.v);
			this.cameraOriginPos.x = this.cameraOriginPos.x + arg0.x * this.cameraMoveSpeed;
			BattleMain.instance.Main.currentGeScene.GetCamera().GetController().SetCameraPos(this.cameraOriginPos);
		}

		// Token: 0x0600A3C7 RID: 41927 RVA: 0x00219999 File Offset: 0x00217D99
		public void SetTimeProgress(int curValue, int maxValue)
		{
			this.timeProgress.value = (float)curValue / (float)maxValue;
		}

		// Token: 0x0600A3C8 RID: 41928 RVA: 0x002199AC File Offset: 0x00217DAC
		public void SetBulletProgress(int curValue, int maxValue)
		{
			int num = curValue % 10;
			if (num == 0)
			{
				num = 10;
			}
			if (curValue <= maxValue && this.danke != null)
			{
				Transform transform = Object.Instantiate<Transform>(this.danke, this.danke.parent, true);
				transform.position = this.bulleteList[num - 1].transform.position + Vector3.left * 20f;
				transform.gameObject.SetActive(true);
				Object.Destroy(transform.gameObject, 1f);
			}
			int count = this.bullteContainerlist.Count;
			for (int i = 0; i < count; i++)
			{
				if (i < num)
				{
					this.bulleteList[i].SetActive(false);
				}
				else
				{
					this.bulleteList[i].SetActive(true);
				}
			}
		}

		// Token: 0x0600A3C9 RID: 41929 RVA: 0x00219A94 File Offset: 0x00217E94
		public Vector3 GetBulletPosition(int curBullet)
		{
			int num = curBullet % 10;
			if (num == 0)
			{
				num = 10;
			}
			return this.bulleteList[num - 1].transform.position;
		}

		// Token: 0x0600A3CA RID: 41930 RVA: 0x00219AC7 File Offset: 0x00217EC7
		public void PlayFireAnimation()
		{
			if (this.fireAnim != null)
			{
				this.fireAnim.DORestart(false);
			}
		}

		// Token: 0x0600A3CB RID: 41931 RVA: 0x00219AE6 File Offset: 0x00217EE6
		public RectTransform GetTargetParent()
		{
			return this.target.parent as RectTransform;
		}

		// Token: 0x0600A3CC RID: 41932 RVA: 0x00219AF8 File Offset: 0x00217EF8
		private void _OnJoyStickStop()
		{
			if (this.JoyStickMoveCallBack != null)
			{
				this.JoyStickMoveCallBack();
			}
		}

		// Token: 0x0600A3CD RID: 41933 RVA: 0x00219B10 File Offset: 0x00217F10
		public void SetJoyStickMoveCallBack(Action action)
		{
			this.JoyStickMoveCallBack = action;
		}

		// Token: 0x0600A3CE RID: 41934 RVA: 0x00219B19 File Offset: 0x00217F19
		public void RemoveJoyStickMoveCallBack()
		{
			this.JoyStickMoveCallBack = null;
		}

		// Token: 0x0600A3CF RID: 41935 RVA: 0x00219B24 File Offset: 0x00217F24
		protected override void _OnCloseFrame()
		{
			this.maskMaterial.material.SetTextureOffset("_Mask", Vector2.zero);
			InputManager.instance.ReleaseJoyStickMoveEndCallback(new UnityAction(this._OnJoyStickStop));
			InputManager.instance.ReleaseJoyStickMoveCallback(new UnityAction<Vector2>(this._OnJoyStickMove));
			this.RemoveJoyStickMoveCallBack();
		}

		// Token: 0x04005B5E RID: 23390
		private RectTransform target;

		// Token: 0x04005B5F RID: 23391
		private Image bulluteProgress;

		// Token: 0x04005B60 RID: 23392
		private Slider timeProgress;

		// Token: 0x04005B61 RID: 23393
		private Action JoyStickMoveCallBack;

		// Token: 0x04005B62 RID: 23394
		private Vector3 cameraOriginPos;

		// Token: 0x04005B63 RID: 23395
		private Vector3 targetPos;

		// Token: 0x04005B64 RID: 23396
		private Transform BullteContainer;

		// Token: 0x04005B65 RID: 23397
		private Image maskMaterial;

		// Token: 0x04005B66 RID: 23398
		private Transform danke;

		// Token: 0x04005B67 RID: 23399
		private DOTweenAnimation fireAnim;

		// Token: 0x04005B68 RID: 23400
		private List<GameObject> bulleteList = new List<GameObject>();

		// Token: 0x04005B69 RID: 23401
		private List<GameObject> bullteContainerlist = new List<GameObject>();

		// Token: 0x04005B6A RID: 23402
		private Vector2 v = Vector2.zero;

		// Token: 0x04005B6B RID: 23403
		public float cameraMoveSpeed = 0.2f;

		// Token: 0x04005B6C RID: 23404
		public float targetMoveSpeed = 30f;
	}
}
