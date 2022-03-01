using System;
using System.Collections.Generic;
using Battle;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001093 RID: 4243
	public class ComDungeonBuffTipList : MonoBehaviour
	{
		// Token: 0x06009FE2 RID: 40930 RVA: 0x002010A6 File Offset: 0x001FF4A6
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this._onUpdateBuffList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattleBuffRemoved, new ClientEventSystem.UIEventHandler(this._removeBuffEvent));
			this._onUpdateBuffList(null);
		}

		// Token: 0x06009FE3 RID: 40931 RVA: 0x002010E5 File Offset: 0x001FF4E5
		private void OnDestroy()
		{
			this._clearBuff();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this._onUpdateBuffList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattleBuffRemoved, new ClientEventSystem.UIEventHandler(this._removeBuffEvent));
		}

		// Token: 0x06009FE4 RID: 40932 RVA: 0x00201124 File Offset: 0x001FF524
		private void _removeBuffEvent(UIEvent ui)
		{
			int buffID = (int)ui.Param1;
			ComDungeonBuffTipList.BuffUnit buffUnit = this.mBuffs.Find((ComDungeonBuffTipList.BuffUnit x) => x.buffId == buffID);
			if (buffUnit != null)
			{
				this._destoryBuffUnit(buffUnit);
				this.mBuffs.Remove(buffUnit);
			}
		}

		// Token: 0x06009FE5 RID: 40933 RVA: 0x0020117A File Offset: 0x001FF57A
		private void _destoryBuffUnit(ComDungeonBuffTipList.BuffUnit unit)
		{
			if (null != unit.buffCom)
			{
				Object.Destroy(unit.buffCom.gameObject);
				unit.buffCom = null;
			}
		}

		// Token: 0x06009FE6 RID: 40934 RVA: 0x002011A4 File Offset: 0x001FF5A4
		private void _onUpdateBuffList(UIEvent uiEvent)
		{
			this._clearBuff();
			for (int i = 0; i < DataManager<PlayerBaseData>.GetInstance().buffList.Count; i++)
			{
				DungeonBuff buff = DataManager<PlayerBaseData>.GetInstance().buffList[i];
				this._addBuff(buff);
			}
		}

		// Token: 0x06009FE7 RID: 40935 RVA: 0x002011EF File Offset: 0x001FF5EF
		private void _clearBuff()
		{
			this.mBuffs.RemoveAll(delegate(ComDungeonBuffTipList.BuffUnit x)
			{
				if (null != x.buffCom)
				{
					this._destoryBuffUnit(x);
				}
				return true;
			});
		}

		// Token: 0x06009FE8 RID: 40936 RVA: 0x0020120C File Offset: 0x001FF60C
		private void _addBuff(DungeonBuff buff)
		{
			ComDungeonBuffTipList.BuffUnit buffUnit = new ComDungeonBuffTipList.BuffUnit();
			buffUnit.buffId = buff.id;
			buffUnit.buffDuration = buff.duration;
			buffUnit.buffLeftTime = buff.lefttime;
			buffUnit.buffType = (int)buff.type;
			BuffTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffTable>(buffUnit.buffId, string.Empty, string.Empty);
			if (tableItem == null || tableItem.IconSortOrder <= -1)
			{
				return;
			}
			AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(tableItem.Icon, typeof(Sprite), true, 0U);
			if (assetInst != null && null != assetInst.obj)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/DungeonTipUnit", true, 0U);
				ComTipsUnit component = gameObject.GetComponent<ComTipsUnit>();
				gameObject.name = string.Format(buff.id.ToString(), new object[0]);
				Utility.AttachTo(gameObject, this.mRoot, false);
				Sprite sprite = assetInst.obj as Sprite;
				component.SetPercent(1f);
				component.SetSprite(sprite);
				buffUnit.buffCom = component;
				buffUnit.sortOrder = tableItem.IconSortOrder;
				this.mBuffs.Add(buffUnit);
			}
		}

		// Token: 0x06009FE9 RID: 40937 RVA: 0x00201340 File Offset: 0x001FF740
		private void Update()
		{
			float deltaTime = Time.deltaTime;
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				ComDungeonBuffTipList.BuffUnit buffUnit = this.mBuffs[i];
				if (buffUnit.buffType != 1)
				{
					buffUnit.buffLeftTime -= deltaTime;
					if (buffUnit.buffLeftTime >= 0f)
					{
						float percent = buffUnit.buffLeftTime / buffUnit.buffDuration;
						if (null != buffUnit.buffCom)
						{
							buffUnit.buffCom.SetPercent(percent);
						}
					}
				}
			}
		}

		// Token: 0x04005890 RID: 22672
		private const string kPath = "UIFlatten/Prefabs/BattleUI/DungeonTipUnit";

		// Token: 0x04005891 RID: 22673
		public GameObject mRoot;

		// Token: 0x04005892 RID: 22674
		private List<ComDungeonBuffTipList.BuffUnit> mBuffs = new List<ComDungeonBuffTipList.BuffUnit>();

		// Token: 0x02001094 RID: 4244
		private class BuffUnit : IComparable<ComDungeonBuffTipList.BuffUnit>
		{
			// Token: 0x06009FEB RID: 40939 RVA: 0x002013EC File Offset: 0x001FF7EC
			public BuffUnit()
			{
				this.uid = 0UL;
			}

			// Token: 0x17001993 RID: 6547
			// (get) Token: 0x06009FEC RID: 40940 RVA: 0x002013FC File Offset: 0x001FF7FC
			// (set) Token: 0x06009FED RID: 40941 RVA: 0x00201404 File Offset: 0x001FF804
			public ulong uid { get; set; }

			// Token: 0x17001994 RID: 6548
			// (get) Token: 0x06009FEE RID: 40942 RVA: 0x0020140D File Offset: 0x001FF80D
			// (set) Token: 0x06009FEF RID: 40943 RVA: 0x00201415 File Offset: 0x001FF815
			public int sortOrder { get; set; }

			// Token: 0x17001995 RID: 6549
			// (get) Token: 0x06009FF0 RID: 40944 RVA: 0x0020141E File Offset: 0x001FF81E
			// (set) Token: 0x06009FF1 RID: 40945 RVA: 0x00201426 File Offset: 0x001FF826
			public int buffId { get; set; }

			// Token: 0x17001996 RID: 6550
			// (get) Token: 0x06009FF2 RID: 40946 RVA: 0x0020142F File Offset: 0x001FF82F
			// (set) Token: 0x06009FF3 RID: 40947 RVA: 0x00201437 File Offset: 0x001FF837
			public int buffType { get; set; }

			// Token: 0x17001997 RID: 6551
			// (get) Token: 0x06009FF4 RID: 40948 RVA: 0x00201440 File Offset: 0x001FF840
			// (set) Token: 0x06009FF5 RID: 40949 RVA: 0x00201448 File Offset: 0x001FF848
			public float buffDuration { get; set; }

			// Token: 0x17001998 RID: 6552
			// (get) Token: 0x06009FF6 RID: 40950 RVA: 0x00201451 File Offset: 0x001FF851
			// (set) Token: 0x06009FF7 RID: 40951 RVA: 0x00201459 File Offset: 0x001FF859
			public float buffLeftTime { get; set; }

			// Token: 0x17001999 RID: 6553
			// (get) Token: 0x06009FF8 RID: 40952 RVA: 0x00201462 File Offset: 0x001FF862
			// (set) Token: 0x06009FF9 RID: 40953 RVA: 0x0020146A File Offset: 0x001FF86A
			public ComTipsUnit buffCom { get; set; }

			// Token: 0x06009FFA RID: 40954 RVA: 0x00201473 File Offset: 0x001FF873
			public int CompareTo(ComDungeonBuffTipList.BuffUnit other)
			{
				return other.sortOrder - this.sortOrder;
			}
		}
	}
}
