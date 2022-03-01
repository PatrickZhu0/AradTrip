using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A0C RID: 6668
	public class RoleAttributeTipFrame : ClientFrame
	{
		// Token: 0x060105DE RID: 67038 RVA: 0x00498FE4 File Offset: 0x004973E4
		protected override void _bindExUI()
		{
			this.mMaskBtn = this.mBind.GetCom<ComButtonEx>("maskBtn");
			if (null != this.mMaskBtn)
			{
				this.mMaskBtn.onClick.AddListener(new UnityAction(this._onMaskBtnButtonClick));
			}
			this.mAttackDesc = this.mBind.GetCom<Text>("attackDesc");
			this.mMagicAttDesc = this.mBind.GetCom<Text>("magicAttDesc");
			this.mAttackDefDesc = this.mBind.GetCom<Text>("attackDefDesc");
			this.mMagicDefDesc = this.mBind.GetCom<Text>("magicDefDesc");
			this.mCiriAttDef = this.mBind.GetCom<Text>("ciriAttDef");
			this.mCiriMagicDef = this.mBind.GetCom<Text>("ciriMagicDef");
			this.mAttackSpeedDesc = this.mBind.GetCom<Text>("attackSpeedDesc");
			this.mSpellSpeedDesc = this.mBind.GetCom<Text>("spellSpeedDesc");
			this.mMoveSpeedDesc = this.mBind.GetCom<Text>("moveSpeedDesc");
			this.mDexDesc = this.mBind.GetCom<Text>("dexDesc");
			this.mDodgeDesc = this.mBind.GetCom<Text>("dodgeDesc");
			this.mHpRecoverDesc = this.mBind.GetCom<Text>("hpRecoverDesc");
			this.mResistMagicContent = this.mBind.GetCom<Text>("ResistMagicContent");
			this.mResistMagicTitle = this.mBind.GetCom<Text>("ResistMagicTitle");
			this.mMpRecoverDesc = this.mBind.GetCom<Text>("mpRecoverDesc");
			this.mLabel0 = this.mBind.GetCom<Text>("Label0");
			this.mLabel1 = this.mBind.GetCom<Text>("Label1");
			this.mLabel2 = this.mBind.GetCom<Text>("Label2");
			this.mLabel3 = this.mBind.GetCom<Text>("Label3");
			this.mLabel4 = this.mBind.GetCom<Text>("Label4");
			this.mLabel5 = this.mBind.GetCom<Text>("Label5");
			this.mLabel6 = this.mBind.GetCom<Text>("Label6");
			this.mLabel7 = this.mBind.GetCom<Text>("Label7");
			this.mLabel8 = this.mBind.GetCom<Text>("Label8");
			this.mLabel9 = this.mBind.GetCom<Text>("Label9");
			this.mLabel10 = this.mBind.GetCom<Text>("Label10");
			this.mLabel11 = this.mBind.GetCom<Text>("Label11");
			this.mLabel12 = this.mBind.GetCom<Text>("Label12");
			this.mLabel13 = this.mBind.GetCom<Text>("Label13");
			this.mLabel14 = this.mBind.GetCom<Text>("Label14");
			this.mLabel15 = this.mBind.GetCom<Text>("Label15");
			this.mLabel16 = this.mBind.GetCom<Text>("Label16");
			this.mLabel17 = this.mBind.GetCom<Text>("Label17");
			this.mLabel18 = this.mBind.GetCom<Text>("Label18");
			this.mLabel19 = this.mBind.GetCom<Text>("Label19");
			this.mLabel20 = this.mBind.GetCom<Text>("Label20");
			this.mLabel21 = this.mBind.GetCom<Text>("Label21");
			this.mLabel22 = this.mBind.GetCom<Text>("Label22");
			this.mLabel23 = this.mBind.GetCom<Text>("Label23");
			this.mLabel24 = this.mBind.GetCom<Text>("Label24");
			this.mLabel25 = this.mBind.GetCom<Text>("Label25");
			this.mLabel26 = this.mBind.GetCom<Text>("Label26");
			this.mLabel27 = this.mBind.GetCom<Text>("Label27");
			this.mLabel28 = this.mBind.GetCom<Text>("Label28");
			this.mLabel29 = this.mBind.GetCom<Text>("Label29");
		}

		// Token: 0x060105DF RID: 67039 RVA: 0x00499414 File Offset: 0x00497814
		protected override void _unbindExUI()
		{
			if (null != this.mMaskBtn)
			{
				this.mMaskBtn.onClick.RemoveListener(new UnityAction(this._onMaskBtnButtonClick));
			}
			this.mMaskBtn = null;
			this.mAttackDesc = null;
			this.mMagicAttDesc = null;
			this.mAttackDefDesc = null;
			this.mMagicDefDesc = null;
			this.mCiriAttDef = null;
			this.mCiriMagicDef = null;
			this.mAttackSpeedDesc = null;
			this.mSpellSpeedDesc = null;
			this.mMoveSpeedDesc = null;
			this.mDexDesc = null;
			this.mDodgeDesc = null;
			this.mHpRecoverDesc = null;
			this.mResistMagicContent = null;
			this.mResistMagicTitle = null;
			this.mMpRecoverDesc = null;
			this.mLabel0 = null;
			this.mLabel1 = null;
			this.mLabel2 = null;
			this.mLabel3 = null;
			this.mLabel4 = null;
			this.mLabel5 = null;
			this.mLabel6 = null;
			this.mLabel7 = null;
			this.mLabel8 = null;
			this.mLabel9 = null;
			this.mLabel10 = null;
			this.mLabel11 = null;
			this.mLabel12 = null;
			this.mLabel13 = null;
			this.mLabel14 = null;
			this.mLabel15 = null;
			this.mLabel16 = null;
			this.mLabel17 = null;
			this.mLabel18 = null;
			this.mLabel19 = null;
			this.mLabel20 = null;
			this.mLabel21 = null;
			this.mLabel22 = null;
			this.mLabel23 = null;
			this.mLabel24 = null;
			this.mLabel25 = null;
			this.mLabel26 = null;
			this.mLabel27 = null;
			this.mLabel28 = null;
			this.mLabel29 = null;
		}

		// Token: 0x060105E0 RID: 67040 RVA: 0x00499590 File Offset: 0x00497990
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Tip/RoleAttributeTip";
		}

		// Token: 0x060105E1 RID: 67041 RVA: 0x00499597 File Offset: 0x00497997
		private void OnMaskBtnClick()
		{
			this.frameMgr.CloseFrame<RoleAttributeTipFrame>(this, false);
		}

		// Token: 0x060105E2 RID: 67042 RVA: 0x004995A6 File Offset: 0x004979A6
		private void _onMaskBtnButtonClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<RoleAttributeTipFrame>(this, false);
		}

		// Token: 0x060105E3 RID: 67043 RVA: 0x004995B4 File Offset: 0x004979B4
		protected override void _OnOpenFrame()
		{
			this.labelList.Clear();
			this.InitLabelList();
			this.RefreshRoleAttInfo();
		}

		// Token: 0x060105E4 RID: 67044 RVA: 0x004995CD File Offset: 0x004979CD
		protected override void _OnCloseFrame()
		{
			this.labelList.Clear();
		}

		// Token: 0x060105E5 RID: 67045 RVA: 0x004995DC File Offset: 0x004979DC
		protected void InitLabelList()
		{
			this.labelList = new List<Text>
			{
				this.mLabel0,
				this.mLabel1,
				this.mLabel2,
				this.mLabel3,
				this.mLabel4,
				this.mLabel5,
				this.mLabel6,
				this.mLabel7,
				this.mLabel8,
				this.mLabel9,
				this.mLabel10,
				this.mLabel11,
				this.mLabel12,
				this.mLabel13,
				this.mLabel14,
				this.mLabel15,
				this.mLabel16,
				this.mLabel17,
				this.mLabel18,
				this.mLabel19,
				this.mLabel20,
				this.mLabel21,
				this.mLabel22,
				this.mLabel23,
				this.mLabel24,
				this.mLabel25,
				this.mLabel26,
				this.mLabel27,
				this.mLabel28,
				this.mLabel29
			};
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				FlatBufferArray<int> recommendedAttributeIndex = tableItem.RecommendedAttributeIndex;
				for (int i = 0; i < recommendedAttributeIndex.Count; i++)
				{
					if (recommendedAttributeIndex[i] <= this.labelList.Count && recommendedAttributeIndex[i] > 0)
					{
						this.labelList[recommendedAttributeIndex[i] - 1].text = string.Format(TR.Value("package_special_attributes_desc"), this.labelList[recommendedAttributeIndex[i] - 1].text);
					}
				}
			}
		}

		// Token: 0x060105E6 RID: 67046 RVA: 0x00499808 File Offset: 0x00497C08
		private void RefreshRoleAttInfo()
		{
			DisplayAttribute mainPlayerActorAttribute = BeUtility.GetMainPlayerActorAttribute(false, false);
			BeEntityData entityData = BeUtility.GetMainPlayerActor(false, null, SkillSystemSourceType.None).GetEntityData();
			BattleData battleData = entityData.battleData;
			if (this.mAttackDesc)
			{
				this.mAttackDesc.text = string.Format("对0防御的对象造成{0}点伤害，并造成{1}点无视防御的追加伤害", battleData.displayAttack, battleData.ignoreDefAttackAdd);
			}
			if (this.mMagicAttDesc)
			{
				this.mMagicAttDesc.text = string.Format("对0防御的对象造成{0}点伤害，并造成{1}点无视防御的追加伤害", battleData.displayMagicAttack, battleData.ignoreDefMagicAttackAdd);
			}
			if (this.mAttackDefDesc)
			{
				this.mAttackDefDesc.text = string.Format("被相同Lv的对象攻击时，减少{0}%受到的伤害   物理防御提升后，将减少中毒、出血、灼伤和感电的伤害", this.GetReduceRate(entityData.level, battleData.fDefence));
			}
			if (this.mMagicDefDesc)
			{
				this.mMagicDefDesc.text = string.Format("被相同Lv的对象攻击时，减少{0}%受到的伤害   魔法防御提升后，将减少中毒、出血、灼伤和感电的伤害", this.GetReduceRate(entityData.level, battleData.fMagicDefence));
			}
			if (this.mCiriAttDef)
			{
				if (mainPlayerActorAttribute.ciriticalAttack < 0f)
				{
					this.mCiriAttDef.text = string.Format("降低物理攻击造成额外伤害的概率{0}%", Mathf.Abs(mainPlayerActorAttribute.ciriticalAttack));
				}
				else
				{
					this.mCiriAttDef.text = string.Format("提升物理攻击造成额外伤害的概率{0}%", mainPlayerActorAttribute.ciriticalAttack);
				}
			}
			if (this.mCiriMagicDef)
			{
				if (mainPlayerActorAttribute.ciriticalMagicAttack < 0f)
				{
					this.mCiriMagicDef.text = string.Format("降低魔法攻击造成额外伤害的概率{0}%", Mathf.Abs(mainPlayerActorAttribute.ciriticalMagicAttack));
				}
				else
				{
					this.mCiriMagicDef.text = string.Format("提升魔法攻击造成额外伤害的概率{0}%", mainPlayerActorAttribute.ciriticalMagicAttack);
				}
			}
			if (this.mAttackSpeedDesc)
			{
				if (mainPlayerActorAttribute.attackSpeed < 0f)
				{
					this.mAttackSpeedDesc.text = string.Format("影响玩家物理攻击的出手速度，降低量为{0}%", Mathf.Abs(mainPlayerActorAttribute.attackSpeed));
				}
				else
				{
					this.mAttackSpeedDesc.text = string.Format("影响玩家物理攻击的出手速度，提升量为{0}%", mainPlayerActorAttribute.attackSpeed);
				}
			}
			if (this.mSpellSpeedDesc)
			{
				if (mainPlayerActorAttribute.spellSpeed < 0f)
				{
					this.mSpellSpeedDesc.text = string.Format("影响玩家施放魔法的施放时间，降低量为{0}%", Mathf.Abs(mainPlayerActorAttribute.spellSpeed));
				}
				else
				{
					this.mSpellSpeedDesc.text = string.Format("影响玩家施放魔法的施放时间，提升量为{0}%", mainPlayerActorAttribute.spellSpeed);
				}
			}
			if (this.mMoveSpeedDesc)
			{
				if (mainPlayerActorAttribute.moveSpeed < 0f)
				{
					this.mMoveSpeedDesc.text = string.Format("降低角色的移动速度{0}%", Mathf.Abs(mainPlayerActorAttribute.moveSpeed));
				}
				else
				{
					this.mMoveSpeedDesc.text = string.Format("提升角色的移动速度{0}%", mainPlayerActorAttribute.moveSpeed);
				}
			}
			if (this.mDexDesc)
			{
				if (mainPlayerActorAttribute.dex < 0f)
				{
					this.mDexDesc.text = string.Format("额外降低角色攻击时的成功几率{0}%", Mathf.Abs(mainPlayerActorAttribute.dex));
				}
				else
				{
					this.mDexDesc.text = string.Format("额外提升角色攻击时的成功几率{0}%", mainPlayerActorAttribute.dex);
				}
			}
			if (this.mDodgeDesc)
			{
				if (mainPlayerActorAttribute.dodge < 0f)
				{
					this.mDodgeDesc.text = string.Format("额外降低角色被攻击时的躲避几率{0}%", Mathf.Abs(mainPlayerActorAttribute.dodge));
				}
				else
				{
					this.mDodgeDesc.text = string.Format("额外提升角色被攻击时的躲避几率{0}%", mainPlayerActorAttribute.dodge);
				}
			}
			if (this.mHpRecoverDesc)
			{
				this.mHpRecoverDesc.text = string.Format("每分钟恢复{0}的血量", mainPlayerActorAttribute.hpRecover);
			}
			if (this.mMpRecoverDesc)
			{
				this.mMpRecoverDesc.text = string.Format("每分钟恢复{0}的魔力", mainPlayerActorAttribute.mpRecover);
			}
			if (this.mResistMagicTitle != null)
			{
				this.mResistMagicTitle.text = TR.Value("resist_magic_title");
			}
			if (this.mResistMagicContent != null)
			{
				this.mResistMagicContent.text = TR.Value("resist_magic_description");
			}
		}

		// Token: 0x060105E7 RID: 67047 RVA: 0x00499CBC File Offset: 0x004980BC
		private int GetReduceRate(int level, int disPlayDefend)
		{
			float num = 0f;
			int num2 = 200 * level + disPlayDefend;
			if (num2 != 0)
			{
				num = (float)disPlayDefend * 1f / (float)num2;
			}
			return (int)(Math.Round((double)num, 2) * 100.0);
		}

		// Token: 0x0400A5DC RID: 42460
		private List<Text> labelList = new List<Text>();

		// Token: 0x0400A5DD RID: 42461
		private ComButtonEx mMaskBtn;

		// Token: 0x0400A5DE RID: 42462
		private Text mAttackDesc;

		// Token: 0x0400A5DF RID: 42463
		private Text mMagicAttDesc;

		// Token: 0x0400A5E0 RID: 42464
		private Text mAttackDefDesc;

		// Token: 0x0400A5E1 RID: 42465
		private Text mMagicDefDesc;

		// Token: 0x0400A5E2 RID: 42466
		private Text mCiriAttDef;

		// Token: 0x0400A5E3 RID: 42467
		private Text mCiriMagicDef;

		// Token: 0x0400A5E4 RID: 42468
		private Text mAttackSpeedDesc;

		// Token: 0x0400A5E5 RID: 42469
		private Text mSpellSpeedDesc;

		// Token: 0x0400A5E6 RID: 42470
		private Text mMoveSpeedDesc;

		// Token: 0x0400A5E7 RID: 42471
		private Text mDexDesc;

		// Token: 0x0400A5E8 RID: 42472
		private Text mDodgeDesc;

		// Token: 0x0400A5E9 RID: 42473
		private Text mHpRecoverDesc;

		// Token: 0x0400A5EA RID: 42474
		private Text mResistMagicContent;

		// Token: 0x0400A5EB RID: 42475
		private Text mResistMagicTitle;

		// Token: 0x0400A5EC RID: 42476
		private Text mMpRecoverDesc;

		// Token: 0x0400A5ED RID: 42477
		private Text mLabel0;

		// Token: 0x0400A5EE RID: 42478
		private Text mLabel1;

		// Token: 0x0400A5EF RID: 42479
		private Text mLabel2;

		// Token: 0x0400A5F0 RID: 42480
		private Text mLabel3;

		// Token: 0x0400A5F1 RID: 42481
		private Text mLabel4;

		// Token: 0x0400A5F2 RID: 42482
		private Text mLabel5;

		// Token: 0x0400A5F3 RID: 42483
		private Text mLabel6;

		// Token: 0x0400A5F4 RID: 42484
		private Text mLabel7;

		// Token: 0x0400A5F5 RID: 42485
		private Text mLabel8;

		// Token: 0x0400A5F6 RID: 42486
		private Text mLabel9;

		// Token: 0x0400A5F7 RID: 42487
		private Text mLabel10;

		// Token: 0x0400A5F8 RID: 42488
		private Text mLabel11;

		// Token: 0x0400A5F9 RID: 42489
		private Text mLabel12;

		// Token: 0x0400A5FA RID: 42490
		private Text mLabel13;

		// Token: 0x0400A5FB RID: 42491
		private Text mLabel14;

		// Token: 0x0400A5FC RID: 42492
		private Text mLabel15;

		// Token: 0x0400A5FD RID: 42493
		private Text mLabel16;

		// Token: 0x0400A5FE RID: 42494
		private Text mLabel17;

		// Token: 0x0400A5FF RID: 42495
		private Text mLabel18;

		// Token: 0x0400A600 RID: 42496
		private Text mLabel19;

		// Token: 0x0400A601 RID: 42497
		private Text mLabel20;

		// Token: 0x0400A602 RID: 42498
		private Text mLabel21;

		// Token: 0x0400A603 RID: 42499
		private Text mLabel22;

		// Token: 0x0400A604 RID: 42500
		private Text mLabel23;

		// Token: 0x0400A605 RID: 42501
		private Text mLabel24;

		// Token: 0x0400A606 RID: 42502
		private Text mLabel25;

		// Token: 0x0400A607 RID: 42503
		private Text mLabel26;

		// Token: 0x0400A608 RID: 42504
		private Text mLabel27;

		// Token: 0x0400A609 RID: 42505
		private Text mLabel28;

		// Token: 0x0400A60A RID: 42506
		private Text mLabel29;
	}
}
