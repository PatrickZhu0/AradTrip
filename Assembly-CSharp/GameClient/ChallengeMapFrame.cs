using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020014C7 RID: 5319
	public class ChallengeMapFrame : ClientFrame
	{
		// Token: 0x0600CE33 RID: 52787 RVA: 0x0032CE24 File Offset: 0x0032B224
		public static void OpenLinkFrame(string strParam)
		{
			ChallengeUtility.OnCloseChallengeMapFrame();
			try
			{
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length > 0)
				{
					int modelType = 1;
					int baseDungeonId = 0;
					int detailDungeonId = 0;
					int num = array.Length;
					if (num == 1)
					{
						modelType = int.Parse(array[0]);
						int num2 = int.Parse(array[0]);
						if (num2 > 1000)
						{
							DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(num2, string.Empty, string.Empty);
							if (tableItem != null)
							{
								modelType = (int)ChallengeMapFrame.GetModelType(tableItem.SubType);
								DungeonID dungeonID = new DungeonID(num2);
								if (dungeonID != null)
								{
									baseDungeonId = dungeonID.dungeonIDWithOutDiff;
									detailDungeonId = dungeonID.dungeonID;
								}
							}
						}
					}
					else if (num == 2)
					{
						modelType = int.Parse(array[0]);
						baseDungeonId = int.Parse(array[1]);
					}
					else if (num == 3)
					{
						modelType = int.Parse(array[0]);
						baseDungeonId = int.Parse(array[1]);
						detailDungeonId = int.Parse(array[2]);
					}
					ChallengeUtility.OnOpenChallengeMapFrame((DungeonModelTable.eType)modelType, baseDungeonId, detailDungeonId);
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("ChallengeSelectFrame OpenLinkFrame throw exception {0}", new object[]
				{
					ex.ToString()
				});
			}
		}

		// Token: 0x0600CE34 RID: 52788 RVA: 0x0032CF5C File Offset: 0x0032B35C
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Challenge/ChallengeMapFrame";
		}

		// Token: 0x0600CE35 RID: 52789 RVA: 0x0032CF64 File Offset: 0x0032B364
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mChallengeMapView != null)
			{
				ChallengeMapParamDataModel paramDataModel = null;
				if (this.userData != null)
				{
					paramDataModel = (ChallengeMapParamDataModel)this.userData;
				}
				this.mChallengeMapView.InitView(paramDataModel);
			}
		}

		// Token: 0x0600CE36 RID: 52790 RVA: 0x0032CFB0 File Offset: 0x0032B3B0
		private static DungeonModelTable.eType GetModelType(DungeonTable.eSubType subType)
		{
			switch (subType)
			{
			case DungeonTable.eSubType.S_DEVILDDOM:
				return DungeonModelTable.eType.VoidCrackModel;
			default:
				switch (subType)
				{
				case DungeonTable.eSubType.S_HELL:
				case DungeonTable.eSubType.S_HELL_ENTRY:
					break;
				default:
					if (subType == DungeonTable.eSubType.S_YUANGU)
					{
						return DungeonModelTable.eType.AncientModel;
					}
					if (subType != DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL)
					{
						return DungeonModelTable.eType.DeepModel;
					}
					break;
				}
				break;
			case DungeonTable.eSubType.S_LIMIT_TIME_HELL:
				break;
			case DungeonTable.eSubType.S_WEEK_HELL:
			case DungeonTable.eSubType.S_WEEK_HELL_ENTRY:
			case DungeonTable.eSubType.S_WEEK_HELL_PER:
				return DungeonModelTable.eType.WeekHellModel;
			case DungeonTable.eSubType.S_RAID_DUNGEON:
				return DungeonModelTable.eType.TeamDuplicationModel;
			}
			return DungeonModelTable.eType.DeepModel;
		}

		// Token: 0x0600CE37 RID: 52791 RVA: 0x0032D01D File Offset: 0x0032B41D
		protected override void _bindExUI()
		{
			this.mChallengeMapView = this.mBind.GetCom<ChallengeMapView>("ChallengeMapView");
		}

		// Token: 0x0600CE38 RID: 52792 RVA: 0x0032D035 File Offset: 0x0032B435
		protected override void _unbindExUI()
		{
			this.mChallengeMapView = null;
		}

		// Token: 0x04007865 RID: 30821
		private ChallengeMapView mChallengeMapView;
	}
}
