using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000F8E RID: 3982
	internal class PreloadManager
	{
		// Token: 0x06009A05 RID: 39429 RVA: 0x001D9F17 File Offset: 0x001D8317
		public static void ClearCache()
		{
			PreloadManager.cachedResID.Clear();
		}

		// Token: 0x06009A06 RID: 39430 RVA: 0x001D9F23 File Offset: 0x001D8323
		public static void AddCache(int key)
		{
			if (!PreloadManager.cachedResID.Contains(key))
			{
				PreloadManager.cachedResID.Add(key);
			}
		}

		// Token: 0x06009A07 RID: 39431 RVA: 0x001D9F40 File Offset: 0x001D8340
		public static bool IsCached(int key)
		{
			return PreloadManager.cachedResID.Contains(key);
		}

		// Token: 0x06009A08 RID: 39432 RVA: 0x001D9F50 File Offset: 0x001D8350
		public static void PreloadActionInfo(BDEntityActionInfo data, BeActionFrameMgr frameMgr, SkillFileListCache fileCache, bool useCube = false)
		{
			if (Utility.IsStringValid(data.hitEffectAsset.m_AssetPath))
			{
				MonoSingleton<CResPreloader>.instance.AddRes(data.hitEffectAsset.m_AssetPath, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
			}
			if (!useCube)
			{
				MonoSingleton<AudioManager>.instance.PreloadSound(data.hitSFXID);
			}
			for (int i = 0; i < data.vFramesData.Count; i++)
			{
				BDEntityActionFrameData bdentityActionFrameData = data.vFramesData[i];
				if (bdentityActionFrameData != null)
				{
					for (int j = 0; j < bdentityActionFrameData.pEvents.Count; j++)
					{
						bdentityActionFrameData.pEvents[j].PreparePreload(frameMgr, fileCache, useCube);
					}
				}
			}
			if (!useCube)
			{
				for (int k = 0; k < data.vAttachFrames.Count; k++)
				{
					BeAttachFrames beAttachFrames = data.vAttachFrames[k];
					if (beAttachFrames != null)
					{
						List<string> list = null;
						for (int l = 0; l < beAttachFrames.animations.Length; l++)
						{
							if (list == null)
							{
								list = new List<string>();
							}
							if (beAttachFrames.animations[l].anim.Length > 0)
							{
								list.Add(beAttachFrames.animations[l].anim);
							}
						}
						int extData = 0;
						if (list != null && list.Count > 0)
						{
							extData = 2;
						}
						MonoSingleton<CResPreloader>.instance.AddRes(beAttachFrames.entityAsset.m_AssetPath, false, 1, null, extData, list, CResPreloader.ResType.OBJECT, null);
					}
				}
			}
		}

		// Token: 0x06009A09 RID: 39433 RVA: 0x001DA0DC File Offset: 0x001D84DC
		public static void PreloadResIDOnly(int resID)
		{
			if (resID == 0)
			{
				return;
			}
			ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			MonoSingleton<CResPreloader>.instance.AddRes(tableItem.ModelPath, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
		}

		// Token: 0x06009A0A RID: 39434 RVA: 0x001DA124 File Offset: 0x001D8524
		public static void PreloadResID(int resID, BeActionFrameMgr frameMgr, SkillFileListCache fileCache, bool needPreloadAnimation = false)
		{
			if (resID == 0)
			{
				return;
			}
			if (PreloadManager.IsCached(resID))
			{
				return;
			}
			PreloadManager.AddCache(resID);
			ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			List<string> list = null;
			if (needPreloadAnimation)
			{
				list = ListPool<string>.Get();
			}
			for (int i = 0; i < tableItem.ActionConfigPath.Count; i++)
			{
				string text = tableItem.ActionConfigPath[i];
				if (Utility.IsStringValid(text))
				{
					List<BDEntityActionInfo> list2 = ListPool<BDEntityActionInfo>.Get();
					BDEntityActionInfo.SaveLoad(PreloadManager.battleType, text, null, true, needPreloadAnimation, list2, list, null);
					ListPool<BDEntityActionInfo>.Release(list2);
				}
			}
			if (needPreloadAnimation)
			{
				MonoSingleton<CResPreloader>.instance.AddRes(tableItem.ModelPath, false, 1, null, 1, list, CResPreloader.ResType.OBJECT, null);
			}
			else
			{
				MonoSingleton<CResPreloader>.instance.AddRes(tableItem.ModelPath, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
			}
			if (Utility.IsStringValid(tableItem.IconPath))
			{
				MonoSingleton<CResPreloader>.instance.AddRes(tableItem.IconPath, false, 1, null, 0, null, CResPreloader.ResType.RES, typeof(Sprite));
			}
			if (needPreloadAnimation)
			{
				ListPool<string>.Release(list);
			}
		}

		// Token: 0x06009A0B RID: 39435 RVA: 0x001DA244 File Offset: 0x001D8644
		public static void PreloadEffectID(int effectID, BeActionFrameMgr frameMgr, SkillFileListCache fileCache)
		{
			if (effectID <= 0)
			{
				return;
			}
			EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(effectID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SummonID > 0)
			{
				if (tableItem.SummonRandList.Count >= 2)
				{
					for (int i = 0; i < tableItem.SummonRandList.Count; i++)
					{
						PreloadManager.PreloadMonsterID(tableItem.SummonRandList[i], frameMgr, fileCache, false);
					}
				}
				else
				{
					PreloadManager.PreloadMonsterID(tableItem.SummonID, frameMgr, fileCache, false);
				}
			}
			PreloadManager.PreloadBuffID(tableItem.BuffID, frameMgr, fileCache, false);
			for (int j = 0; j < tableItem.BuffInfoID.Count; j++)
			{
				PreloadManager.PreloadBuffInfoID(tableItem.BuffInfoID[j], frameMgr, fileCache);
			}
			for (int k = 0; k < tableItem.AttachEntity.Count; k++)
			{
				int num = tableItem.AttachEntity[k];
				if (num > 0)
				{
					PreloadManager.PreloadResID(num, frameMgr, fileCache, false);
				}
			}
		}

		// Token: 0x06009A0C RID: 39436 RVA: 0x001DA350 File Offset: 0x001D8750
		public static void PreloadBuffID(int buffID, BeActionFrameMgr frameMgr, SkillFileListCache fileCache, bool useCube = false)
		{
			if (useCube)
			{
				return;
			}
			if (buffID <= 0)
			{
				return;
			}
			BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(buffID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (Utility.IsStringValid(tableItem.EffectName))
			{
				MonoSingleton<CResPreloader>.instance.AddRes(tableItem.EffectName, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
			}
			if (tableItem.Type == -3)
			{
				PreloadManager.PreloadMonsterID(tableItem.summon_monsterID, frameMgr, fileCache, false);
				for (int i = 0; i < tableItem.summon_entity.Count; i++)
				{
					PreloadManager.PreloadResID(tableItem.summon_entity[i], frameMgr, fileCache, false);
				}
			}
		}

		// Token: 0x06009A0D RID: 39437 RVA: 0x001DA3FC File Offset: 0x001D87FC
		public static void PreloadBuffInfoID(int buffInfoID, BeActionFrameMgr frameMgr, SkillFileListCache fileCache)
		{
			if (buffInfoID <= 0)
			{
				return;
			}
			BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(buffInfoID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			PreloadManager.PreloadBuffID(tableItem.BuffID, frameMgr, fileCache, false);
		}

		// Token: 0x06009A0E RID: 39438 RVA: 0x001DA43C File Offset: 0x001D883C
		public static void PreloadMonsterID(int monsterID, BeActionFrameMgr frameMgr, SkillFileListCache fileCache, bool onlyResID = false)
		{
			if (monsterID <= 0)
			{
				return;
			}
			int num = (monsterID - monsterID / 10000 * 10000) / 100;
			monsterID -= num * 100;
			UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(monsterID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (onlyResID)
			{
				PreloadManager.PreloadResIDOnly(tableItem.Mode);
			}
			else
			{
				PreloadManager.PreloadResID(tableItem.Mode, frameMgr, fileCache, true);
			}
		}

		// Token: 0x06009A0F RID: 39439 RVA: 0x001DA4B0 File Offset: 0x001D88B0
		public static void PreloadAI(UnitTable monsterData)
		{
			if (monsterData == null)
			{
				return;
			}
			List<string> list = new List<string>();
			list.Add(monsterData.AIActionPath);
			list.Add(monsterData.AIDestinationSelectPath);
			list.Add(monsterData.AIEventPath);
			for (int i = 0; i < list.Count; i++)
			{
				if (Utility.IsStringValid(list[i]))
				{
					MonoSingleton<CResPreloader>.instance.AddRes(list[i], false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
				}
			}
		}

		// Token: 0x06009A10 RID: 39440 RVA: 0x001DA530 File Offset: 0x001D8930
		public static void PreloadTriggerBuff(Dictionary<int, List<BuffInfoData>> list, BeActionFrameMgr frameMgr, SkillFileListCache fileCache, bool useCube = false)
		{
			if (useCube)
			{
				return;
			}
			if (list == null)
			{
				return;
			}
			foreach (KeyValuePair<int, List<BuffInfoData>> keyValuePair in list)
			{
				List<BuffInfoData> value = keyValuePair.Value;
				for (int i = 0; i < value.Count; i++)
				{
					PreloadManager.PreloadBuffID(value[i].buffID, frameMgr, fileCache, false);
				}
			}
		}

		// Token: 0x06009A11 RID: 39441 RVA: 0x001DA5A4 File Offset: 0x001D89A4
		public static void PreloadAnimations(BeActor actor)
		{
			foreach (KeyValuePair<string, BDEntityActionInfo> keyValuePair in actor.m_cpkEntityInfo._vkActionsMap)
			{
				BDEntityActionInfo value = keyValuePair.Value;
				actor.m_pkGeActor.ProloadAction(value.actionName);
			}
		}

		// Token: 0x06009A12 RID: 39442 RVA: 0x001DA618 File Offset: 0x001D8A18
		public static void PreloadActor(BeActor actor, BeActionFrameMgr frameMgr, SkillFileListCache fileCache, bool useCube = false)
		{
			if (actor == null)
			{
				return;
			}
			if (PreloadManager.IsCached(actor.m_iResID))
			{
				return;
			}
			PreloadManager.AddCache(actor.m_iResID);
			foreach (KeyValuePair<string, BDEntityActionInfo> keyValuePair in actor.m_cpkEntityInfo._vkActionsMap)
			{
				BDEntityActionInfo value = keyValuePair.Value;
				PreloadManager.PreloadActionInfo(value, frameMgr, fileCache, useCube);
			}
			for (int i = 0; i < actor.m_cpkEntityInfo.tagActionInfo.Length; i++)
			{
				BDEntityRes.TagActionInfo tagActionInfo = actor.m_cpkEntityInfo.tagActionInfo[i];
				if (tagActionInfo != null)
				{
					foreach (KeyValuePair<string, BDEntityActionInfo> keyValuePair2 in tagActionInfo.actionMap)
					{
						BDEntityActionInfo value2 = keyValuePair2.Value;
						PreloadManager.PreloadActionInfo(value2, frameMgr, fileCache, useCube);
					}
				}
			}
			if (actor.accompanyData.id > 0)
			{
				PreloadManager.PreloadMonsterID(actor.accompanyData.id, frameMgr, fileCache, false);
			}
			PreloadManager.PreloadTriggerBuff(actor.buffController.GetTriggerBuffList(), frameMgr, fileCache, useCube);
			PreloadManager.PreloadAnimations(actor);
		}

		// Token: 0x04004F57 RID: 20311
		public static BattleType battleType = BattleType.None;

		// Token: 0x04004F58 RID: 20312
		public static List<int> cachedResID = new List<int>();
	}
}
