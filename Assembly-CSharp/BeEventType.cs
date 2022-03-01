using System;
using System.ComponentModel;

// Token: 0x02004180 RID: 16768
public enum BeEventType
{
	// Token: 0x0401084E RID: 67662
	[Description("进入战斗")]
	onEnterBattle = 1,
	// Token: 0x0401084F RID: 67663
	[Description("场景清空")]
	onSceneClear,
	// Token: 0x04010850 RID: 67664
	[Description("连击")]
	onBattleCombo,
	// Token: 0x04010851 RID: 67665
	[Description("连击中断")]
	onBattleComboStop,
	// Token: 0x04010852 RID: 67666
	[Description("进入场景")]
	onEnterScene,
	// Token: 0x04010853 RID: 67667
	OnBeforePassDoor,
	// Token: 0x04010854 RID: 67668
	onStartPassDoor,
	// Token: 0x04010855 RID: 67669
	onPassedDoor,
	// Token: 0x04010856 RID: 67670
	onDeadTowerEnterNextLayer,
	// Token: 0x04010857 RID: 67671
	[Description("hp改变")]
	onHPChanged,
	// Token: 0x04010858 RID: 67672
	[Description("受伤")]
	onHurt,
	// Token: 0x04010859 RID: 67673
	[Description("死亡")]
	onDead,
	// Token: 0x0401085A RID: 67674
	onAfterDead,
	// Token: 0x0401085B RID: 67675
	onBeforeAfterDead,
	// Token: 0x0401085C RID: 67676
	[Description("出生")]
	onBirth,
	// Token: 0x0401085D RID: 67677
	onReborn,
	// Token: 0x0401085E RID: 67678
	[Description("释放技能")]
	onCastSkill,
	// Token: 0x0401085F RID: 67679
	onCastSkillFinish,
	// Token: 0x04010860 RID: 67680
	[Description("走到边界处")]
	onWalkToAreaLimit,
	// Token: 0x04010861 RID: 67681
	[Description("空中最高处")]
	onReachTop,
	// Token: 0x04010862 RID: 67682
	[Description("触底")]
	onTouchGround,
	// Token: 0x04010863 RID: 67683
	[Description("状态切换")]
	onStateChange,
	// Token: 0x04010864 RID: 67684
	onStateChangeEnd,
	// Token: 0x04010865 RID: 67685
	OnBuffHpChange,
	// Token: 0x04010866 RID: 67686
	onChangeFace,
	// Token: 0x04010867 RID: 67687
	OnAttackResult,
	// Token: 0x04010868 RID: 67688
	OnDoAttckResult,
	// Token: 0x04010869 RID: 67689
	OnChangeEffectTime,
	// Token: 0x0401086A RID: 67690
	onCastNormalAttack,
	// Token: 0x0401086B RID: 67691
	onSpecialSkillComboRelease,
	// Token: 0x0401086C RID: 67692
	onBeforeGenBullet,
	// Token: 0x0401086D RID: 67693
	onAfterGenBullet,
	// Token: 0x0401086E RID: 67694
	onChangeLaunchProNum,
	// Token: 0x0401086F RID: 67695
	onChangeModifySpeed,
	// Token: 0x04010870 RID: 67696
	onChangeSkillTime,
	// Token: 0x04010871 RID: 67697
	onCollide,
	// Token: 0x04010872 RID: 67698
	onCollideOther,
	// Token: 0x04010873 RID: 67699
	onBeforeHit,
	// Token: 0x04010874 RID: 67700
	onBeforeOtherHit,
	// Token: 0x04010875 RID: 67701
	onAfterCalFirstDamage,
	// Token: 0x04010876 RID: 67702
	onAfterFinalDamage,
	// Token: 0x04010877 RID: 67703
	onAfterFinalDamageNew,
	// Token: 0x04010878 RID: 67704
	onBeHitAfterFinalDamage,
	// Token: 0x04010879 RID: 67705
	onHit,
	// Token: 0x0401087A RID: 67706
	onHitAfterAddBuff,
	// Token: 0x0401087B RID: 67707
	onHitOtherAfterAddBuff,
	// Token: 0x0401087C RID: 67708
	BlockSuccess,
	// Token: 0x0401087D RID: 67709
	ConfigCommand,
	// Token: 0x0401087E RID: 67710
	onHitOther,
	// Token: 0x0401087F RID: 67711
	onHitOtherAfterHurt,
	// Token: 0x04010880 RID: 67712
	onGrabbed,
	// Token: 0x04010881 RID: 67713
	onKill,
	// Token: 0x04010882 RID: 67714
	onBeKilled,
	// Token: 0x04010883 RID: 67715
	onMarkRemove,
	// Token: 0x04010884 RID: 67716
	onRemove,
	// Token: 0x04010885 RID: 67717
	onHitCritical,
	// Token: 0x04010886 RID: 67718
	onHitCriticalBeforDamage,
	// Token: 0x04010887 RID: 67719
	onHPChange,
	// Token: 0x04010888 RID: 67720
	onMPChange,
	// Token: 0x04010889 RID: 67721
	onAttrChange,
	// Token: 0x0401088A RID: 67722
	OnChangeWeapon,
	// Token: 0x0401088B RID: 67723
	OnChangeWeaponEnd,
	// Token: 0x0401088C RID: 67724
	onChangeEquipEnd,
	// Token: 0x0401088D RID: 67725
	onBreakAction,
	// Token: 0x0401088E RID: 67726
	onBackHit,
	// Token: 0x0401088F RID: 67727
	onBeforeSummon,
	// Token: 0x04010890 RID: 67728
	onSummon,
	// Token: 0x04010891 RID: 67729
	onChangeSummonScale,
	// Token: 0x04010892 RID: 67730
	onChangeSummonLifeTime,
	// Token: 0x04010893 RID: 67731
	onAddBuff,
	// Token: 0x04010894 RID: 67732
	onRemoveBuff,
	// Token: 0x04010895 RID: 67733
	OnAddBuffToOthers,
	// Token: 0x04010896 RID: 67734
	onChangeHurtValue,
	// Token: 0x04010897 RID: 67735
	onSpecialDead,
	// Token: 0x04010898 RID: 67736
	onReplaceHurtTableDamageData,
	// Token: 0x04010899 RID: 67737
	onReplaceHurtTableCiriticalData,
	// Token: 0x0401089A RID: 67738
	onBreakActionChangeEvent,
	// Token: 0x0401089B RID: 67739
	onCollideByProjectile,
	// Token: 0x0401089C RID: 67740
	onXInBlock,
	// Token: 0x0401089D RID: 67741
	onYInBlock,
	// Token: 0x0401089E RID: 67742
	OnChangeSpeed,
	// Token: 0x0401089F RID: 67743
	OnUseCrystal,
	// Token: 0x040108A0 RID: 67744
	onPetSkill,
	// Token: 0x040108A1 RID: 67745
	onSkillPressButtonCombo,
	// Token: 0x040108A2 RID: 67746
	OnReleaseButtonTrigger,
	// Token: 0x040108A3 RID: 67747
	onAddRune,
	// Token: 0x040108A4 RID: 67748
	onClearRune,
	// Token: 0x040108A5 RID: 67749
	OnConsumeRune,
	// Token: 0x040108A6 RID: 67750
	onPreSetSkillAction,
	// Token: 0x040108A7 RID: 67751
	onActionLoop,
	// Token: 0x040108A8 RID: 67752
	onJumpBackAttack,
	// Token: 0x040108A9 RID: 67753
	onReplaceSkill,
	// Token: 0x040108AA RID: 67754
	onSkillCurFrame,
	// Token: 0x040108AB RID: 67755
	onChangeAttackDBox,
	// Token: 0x040108AC RID: 67756
	onChangeAttackZDim,
	// Token: 0x040108AD RID: 67757
	onSkillPostInit,
	// Token: 0x040108AE RID: 67758
	onSkillCoolDownStart,
	// Token: 0x040108AF RID: 67759
	onSkillCoolDownFinish,
	// Token: 0x040108B0 RID: 67760
	onChaserUse,
	// Token: 0x040108B1 RID: 67761
	onComboSkillCDCoolDown,
	// Token: 0x040108B2 RID: 67762
	onUseJumpBackSkill,
	// Token: 0x040108B3 RID: 67763
	onDuoTianZhanCombo,
	// Token: 0x040108B4 RID: 67764
	onEnterPhase,
	// Token: 0x040108B5 RID: 67765
	onUseMuscleShift,
	// Token: 0x040108B6 RID: 67766
	onBoomerangHit,
	// Token: 0x040108B7 RID: 67767
	onChangeBoomerangStayDuration,
	// Token: 0x040108B8 RID: 67768
	onReplaceComboSkill,
	// Token: 0x040108B9 RID: 67769
	onChangeModelFinish,
	// Token: 0x040108BA RID: 67770
	OnJudgeGrab,
	// Token: 0x040108BB RID: 67771
	OnSelfJudgeGrab,
	// Token: 0x040108BC RID: 67772
	OnGrab,
	// Token: 0x040108BD RID: 67773
	onActorAdd,
	// Token: 0x040108BE RID: 67774
	onActorRemove,
	// Token: 0x040108BF RID: 67775
	OnChangeAttributeDefence,
	// Token: 0x040108C0 RID: 67776
	onChangeClickForce,
	// Token: 0x040108C1 RID: 67777
	OnChangeMoveDir,
	// Token: 0x040108C2 RID: 67778
	OnFakeReborn,
	// Token: 0x040108C3 RID: 67779
	onMishuMagicAttrChange,
	// Token: 0x040108C4 RID: 67780
	onMoveJoystick,
	// Token: 0x040108C5 RID: 67781
	onStopMoveJoystick,
	// Token: 0x040108C6 RID: 67782
	onCanChangeWeaponButton,
	// Token: 0x040108C7 RID: 67783
	onStartMove,
	// Token: 0x040108C8 RID: 67784
	onStopMove,
	// Token: 0x040108C9 RID: 67785
	OnPlayDeadEffect,
	// Token: 0x040108CA RID: 67786
	onExcuteGrab,
	// Token: 0x040108CB RID: 67787
	onEndGrab,
	// Token: 0x040108CC RID: 67788
	onSkillCancel,
	// Token: 0x040108CD RID: 67789
	onSkillStart,
	// Token: 0x040108CE RID: 67790
	onBeExcuteGrab,
	// Token: 0x040108CF RID: 67791
	onNextPhaseBeforeExecute,
	// Token: 0x040108D0 RID: 67792
	onGrabPressCountAdd,
	// Token: 0x040108D1 RID: 67793
	onSkillCanBeInterrupt,
	// Token: 0x040108D2 RID: 67794
	onWillUseSkill,
	// Token: 0x040108D3 RID: 67795
	onSpecialSkillCombo,
	// Token: 0x040108D4 RID: 67796
	onSyncSightCommand,
	// Token: 0x040108D5 RID: 67797
	onChangeAttackCanTriggerSkill,
	// Token: 0x040108D6 RID: 67798
	onChangeYinluoFlag,
	// Token: 0x040108D7 RID: 67799
	onAIStart,
	// Token: 0x040108D8 RID: 67800
	onExecuteAICmd,
	// Token: 0x040108D9 RID: 67801
	onAIMoveEnd,
	// Token: 0x040108DA RID: 67802
	onBuffStart,
	// Token: 0x040108DB RID: 67803
	onBuffRefresh,
	// Token: 0x040108DC RID: 67804
	onBuffUpdate,
	// Token: 0x040108DD RID: 67805
	onBuffFinish,
	// Token: 0x040108DE RID: 67806
	onBuffDispose,
	// Token: 0x040108DF RID: 67807
	onBuffCancel,
	// Token: 0x040108E0 RID: 67808
	onBuffReachLimit,
	// Token: 0x040108E1 RID: 67809
	onBuffCreateEffect,
	// Token: 0x040108E2 RID: 67810
	onBuffRemoveEffect,
	// Token: 0x040108E3 RID: 67811
	onBuffReplaceEffect,
	// Token: 0x040108E4 RID: 67812
	onBuffBeforePostInit,
	// Token: 0x040108E5 RID: 67813
	onChangeBuffAttackRate,
	// Token: 0x040108E6 RID: 67814
	onChangeBuffLevel,
	// Token: 0x040108E7 RID: 67815
	onChangeBuffAttack,
	// Token: 0x040108E8 RID: 67816
	OnChangeAbnormalBuffLevel,
	// Token: 0x040108E9 RID: 67817
	OnBuffDamage,
	// Token: 0x040108EA RID: 67818
	BuffCanAdd,
	// Token: 0x040108EB RID: 67819
	OnBuffDoHurt,
	// Token: 0x040108EC RID: 67820
	onRepeatAttackInterval,
	// Token: 0x040108ED RID: 67821
	onChangeHitThrough,
	// Token: 0x040108EE RID: 67822
	onChangeScreenShakeID,
	// Token: 0x040108EF RID: 67823
	onChangeHitEffect,
	// Token: 0x040108F0 RID: 67824
	onChangeFloatingRate,
	// Token: 0x040108F1 RID: 67825
	onChangeFloatYForce,
	// Token: 0x040108F2 RID: 67826
	onChangeSummonNum,
	// Token: 0x040108F3 RID: 67827
	onChangeSummonNumLimit,
	// Token: 0x040108F4 RID: 67828
	onChangeDamage,
	// Token: 0x040108F5 RID: 67829
	onBeHitChangeDamage,
	// Token: 0x040108F6 RID: 67830
	onChangeBuffTargetRadius,
	// Token: 0x040108F7 RID: 67831
	onChangeBuffRangeRadius,
	// Token: 0x040108F8 RID: 67832
	onChangeXRate,
	// Token: 0x040108F9 RID: 67833
	onChangeFloatXForce,
	// Token: 0x040108FA RID: 67834
	onChangeMagicElement,
	// Token: 0x040108FB RID: 67835
	onChangeMagicElementList,
	// Token: 0x040108FC RID: 67836
	onAddTriggerBuff,
	// Token: 0x040108FD RID: 67837
	onHitEffect,
	// Token: 0x040108FE RID: 67838
	onChangeSummonMonsterAttach,
	// Token: 0x040108FF RID: 67839
	onChangeSummonMonsterAddDamage,
	// Token: 0x04010900 RID: 67840
	onChangeSummonMonsterAddCritiDamage,
	// Token: 0x04010901 RID: 67841
	onAddMechanism,
	// Token: 0x04010902 RID: 67842
	onChangeProjectileSpeed,
	// Token: 0x04010903 RID: 67843
	onChangeHardValue,
	// Token: 0x04010904 RID: 67844
	onDeadProtectEnd,
	// Token: 0x04010905 RID: 67845
	onBackModeEnd,
	// Token: 0x04010906 RID: 67846
	onReachMaxEnergy,
	// Token: 0x04010907 RID: 67847
	onEnergyStatChange,
	// Token: 0x04010908 RID: 67848
	onTrainingPveResetSkillCD,
	// Token: 0x04010909 RID: 67849
	onMagicGirlMonsterChange,
	// Token: 0x0401090A RID: 67850
	onMagicGirlMonsterRestore,
	// Token: 0x0401090B RID: 67851
	onSyncDungeonOperation,
	// Token: 0x0401090C RID: 67852
	onChangeBeHitEffectPos,
	// Token: 0x0401090D RID: 67853
	onChangeBeHitNumberPos,
	// Token: 0x0401090E RID: 67854
	onChangeHitNumberType,
	// Token: 0x0401090F RID: 67855
	RaidBattleChangeMonster,
	// Token: 0x04010910 RID: 67856
	AbnormalBuffHurt,
	// Token: 0x04010911 RID: 67857
	onAddChaser,
	// Token: 0x04010912 RID: 67858
	onRemoveChaser,
	// Token: 0x04010913 RID: 67859
	onMechanism2050RestoreBtn,
	// Token: 0x04010914 RID: 67860
	onCalcRuneAddDamage,
	// Token: 0x04010915 RID: 67861
	onShengguangshouhuAbsorbDamage,
	// Token: 0x04010916 RID: 67862
	onChangeShock,
	// Token: 0x04010917 RID: 67863
	onAfterCalcBuffInfoSkillLV,
	// Token: 0x04010918 RID: 67864
	onMechanism2139ValueChange
}
