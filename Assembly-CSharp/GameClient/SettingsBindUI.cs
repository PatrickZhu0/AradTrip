using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A11 RID: 6673
	public class SettingsBindUI
	{
		// Token: 0x06010622 RID: 67106 RVA: 0x0049B5A8 File Offset: 0x004999A8
		public SettingsBindUI(GameObject root, ClientFrame frame)
		{
			this.currFrame = frame;
			this.mRoot = root;
			this.comBindPath = this.GetCurrGameObjectPath();
			if (string.IsNullOrEmpty(this.comBindPath))
			{
				Logger.LogError("Please set your bindUI's gameObject path!!!!!");
			}
			if (root == null)
			{
				Logger.LogError("Your bindUI's root is null !!!!!");
			}
			if (frame == null)
			{
				Logger.LogError("Your bindUI's root frame is null !!!!!");
			}
			if (this.mBind != null)
			{
				return;
			}
			if (root != null && frame != null)
			{
				string pattern = frame.GetName().Replace("(Clone)", string.Empty);
				string[] array = Regex.Split(this.comBindPath, pattern);
				if (array == null)
				{
					return;
				}
				if (array.Length < 2)
				{
					return;
				}
				if (array[1].StartsWith("/"))
				{
					this.comBindPath = array[1].TrimStart(new char[]
					{
						'/'
					});
				}
			}
		}

		// Token: 0x06010623 RID: 67107 RVA: 0x0049B698 File Offset: 0x00499A98
		public void ShowOut()
		{
			if (!this.isLoadPrefab)
			{
				this.LoadPrefab();
			}
			if (!this.isBinded)
			{
				this.InitBind();
			}
			if (this.mBind)
			{
				this.mBind.gameObject.CustomActive(true);
			}
			this.OnShowOut();
		}

		// Token: 0x06010624 RID: 67108 RVA: 0x0049B6EE File Offset: 0x00499AEE
		public void HideIn()
		{
			this.OnHideIn();
			this.UnInitBind();
			this.isBinded = false;
			if (this.mBind)
			{
				this.mBind.gameObject.CustomActive(false);
			}
		}

		// Token: 0x06010625 RID: 67109 RVA: 0x0049B724 File Offset: 0x00499B24
		public void Update()
		{
			this.OnUpdate();
		}

		// Token: 0x06010626 RID: 67110 RVA: 0x0049B72C File Offset: 0x00499B2C
		protected virtual void LoadPrefab()
		{
			if (!this.isBinded && this.mRoot != null)
			{
				UIPrefabWrapper uiprefabWrapper = Utility.FindComponent<UIPrefabWrapper>(this.mRoot, this.comBindPath, false);
				if (uiprefabWrapper != null)
				{
					GameObject gameObject = Utility.FindGameObject(this.mRoot, this.comBindPath, true);
					gameObject = uiprefabWrapper.gameObject;
					GameObject gameObject2 = uiprefabWrapper.LoadUIPrefab();
					if (gameObject2 != null)
					{
						gameObject2.name = gameObject.name;
						gameObject2.transform.SetParent(gameObject.transform.parent, false);
						Object.Destroy(gameObject);
					}
					this.mBind = gameObject2.GetComponent<ComCommonBind>();
					this.isLoadPrefab = true;
				}
			}
		}

		// Token: 0x06010627 RID: 67111 RVA: 0x0049B7DD File Offset: 0x00499BDD
		public void CloseFrame()
		{
			this.HideIn();
			this.Close();
		}

		// Token: 0x06010628 RID: 67112 RVA: 0x0049B7EB File Offset: 0x00499BEB
		protected virtual void Close()
		{
		}

		// Token: 0x06010629 RID: 67113 RVA: 0x0049B7ED File Offset: 0x00499BED
		protected virtual void InitBind()
		{
		}

		// Token: 0x0601062A RID: 67114 RVA: 0x0049B7EF File Offset: 0x00499BEF
		protected virtual void UnInitBind()
		{
		}

		// Token: 0x0601062B RID: 67115 RVA: 0x0049B7F1 File Offset: 0x00499BF1
		protected virtual void OnShowOut()
		{
		}

		// Token: 0x0601062C RID: 67116 RVA: 0x0049B7F3 File Offset: 0x00499BF3
		protected virtual void OnHideIn()
		{
		}

		// Token: 0x0601062D RID: 67117 RVA: 0x0049B7F5 File Offset: 0x00499BF5
		protected virtual void OnUpdate()
		{
		}

		// Token: 0x0601062E RID: 67118 RVA: 0x0049B7F7 File Offset: 0x00499BF7
		protected virtual string GetCurrGameObjectPath()
		{
			return string.Empty;
		}

		// Token: 0x0400A659 RID: 42585
		protected ComCommonBind mBind;

		// Token: 0x0400A65A RID: 42586
		protected string comBindPath;

		// Token: 0x0400A65B RID: 42587
		protected ClientFrame currFrame;

		// Token: 0x0400A65C RID: 42588
		private bool isBinded;

		// Token: 0x0400A65D RID: 42589
		private bool isLoadPrefab;

		// Token: 0x0400A65E RID: 42590
		private GameObject mRoot;
	}
}
