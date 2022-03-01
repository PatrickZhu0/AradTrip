using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000EC9 RID: 3785
	public class ComDungeonComboTips : MonoBehaviour
	{
		// Token: 0x060094E9 RID: 38121 RVA: 0x001BF600 File Offset: 0x001BDA00
		private void _useSkill(UIEvent ui)
		{
			int id = (int)ui.Param1;
			this._pushSkill(id);
		}

		// Token: 0x060094EA RID: 38122 RVA: 0x001BF620 File Offset: 0x001BDA20
		public void SetSkills(int[] skills)
		{
			this.mSkills = new List<int>(skills);
			this.mUnits = new ComDungeonComboUnit[this.mSkills.Count];
			for (int i = 0; i < this.mSkills.Count; i++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadRes("UIFlatten/Prefabs/BattleUI/DungeonComboUnit", typeof(GameObject), true, 0U).obj as GameObject;
				Utility.AttachTo(gameObject, base.gameObject, false);
				this.mUnits[i] = gameObject.GetComponent<ComDungeonComboUnit>();
				this.mUnits[i].SetSkill(this.mSkills[i]);
			}
			this._reset();
		}

		// Token: 0x060094EB RID: 38123 RVA: 0x001BF6CB File Offset: 0x001BDACB
		public void BindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonPlayerUseSkill, new ClientEventSystem.UIEventHandler(this._useSkill));
		}

		// Token: 0x060094EC RID: 38124 RVA: 0x001BF6E8 File Offset: 0x001BDAE8
		public void UnbindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonPlayerUseSkill, new ClientEventSystem.UIEventHandler(this._useSkill));
		}

		// Token: 0x060094ED RID: 38125 RVA: 0x001BF705 File Offset: 0x001BDB05
		private void _tickTime()
		{
			this.mCurTime += Time.deltaTime;
			if (this.mCurTime >= this.mDealta)
			{
				this.mState = ComDungeonComboTips.State.Reset;
			}
		}

		// Token: 0x060094EE RID: 38126 RVA: 0x001BF734 File Offset: 0x001BDB34
		private void _reset()
		{
			this.mCurTime = 0f;
			this.mCurIndex = 0;
			for (int i = 0; i < this.mUnits.Length; i++)
			{
				this.mUnits[i].Reset();
			}
			this.mState = ComDungeonComboTips.State.Wait;
		}

		// Token: 0x060094EF RID: 38127 RVA: 0x001BF780 File Offset: 0x001BDB80
		private void _timeout()
		{
			this.mState = ComDungeonComboTips.State.Reset;
		}

		// Token: 0x060094F0 RID: 38128 RVA: 0x001BF78C File Offset: 0x001BDB8C
		private void _matchSkillFail()
		{
			for (int i = 0; i <= this.mCurIndex; i++)
			{
				this.mUnits[i].PlayState(false);
			}
			this.mState = ComDungeonComboTips.State.Fail;
		}

		// Token: 0x060094F1 RID: 38129 RVA: 0x001BF7C8 File Offset: 0x001BDBC8
		private void _matchSkillSucces()
		{
			this.mCurTime = 0f;
			this.mState = ComDungeonComboTips.State.Wait;
			if (this.mCurIndex == this.mSkills.Count - 1)
			{
				this.mState = ComDungeonComboTips.State.Succes;
			}
			this.mUnits[this.mCurIndex].PlayState(true);
			this.mCurIndex++;
			this.mCurIndex %= this.mSkills.Count;
		}

		// Token: 0x060094F2 RID: 38130 RVA: 0x001BF840 File Offset: 0x001BDC40
		private void _pushSkill(int id)
		{
			if (this.mState == ComDungeonComboTips.State.Wait)
			{
				if (this.mCurIndex >= this.mSkills.Count)
				{
					return;
				}
				if (id == this.mSkills[this.mCurIndex])
				{
					this._matchSkillSucces();
				}
				else
				{
					this._matchSkillFail();
				}
			}
		}

		// Token: 0x060094F3 RID: 38131 RVA: 0x001BF898 File Offset: 0x001BDC98
		private void Update()
		{
			this._tickTime();
			switch (this.mState)
			{
			case ComDungeonComboTips.State.TimeOut:
				this._timeout();
				break;
			case ComDungeonComboTips.State.Fail:
			case ComDungeonComboTips.State.Succes:
				if (this.mCurTime > 1f)
				{
					this.mState = ComDungeonComboTips.State.Reset;
				}
				break;
			case ComDungeonComboTips.State.Reset:
				this._reset();
				break;
			}
		}

		// Token: 0x04004BA3 RID: 19363
		public ComDungeonComboUnit[] mUnits;

		// Token: 0x04004BA4 RID: 19364
		public float mDealta = 0.8f;

		// Token: 0x04004BA5 RID: 19365
		public List<int> mSkills = new List<int>();

		// Token: 0x04004BA6 RID: 19366
		private float mCurTime;

		// Token: 0x04004BA7 RID: 19367
		private int mCurIndex;

		// Token: 0x04004BA8 RID: 19368
		public ComDungeonComboTips.State mState;

		// Token: 0x02000ECA RID: 3786
		public enum State
		{
			// Token: 0x04004BAA RID: 19370
			Wait,
			// Token: 0x04004BAB RID: 19371
			TimeOut,
			// Token: 0x04004BAC RID: 19372
			Fail,
			// Token: 0x04004BAD RID: 19373
			Succes,
			// Token: 0x04004BAE RID: 19374
			Reset
		}
	}
}
