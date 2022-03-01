using System;

namespace behaviac
{
	// Token: 0x02002BC5 RID: 11205
	public static class bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Action
	{
		// Token: 0x0601408D RID: 82061 RVA: 0x00604804 File Offset: 0x00602C04
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_Saiche_huoyaotong_Action");
			bt.IsFSM = false;
			Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Action_node2 action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Action_node = new Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Action_node2();
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Action_node.SetId(2);
			bt.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Action_node);
			bt.SetHasEvents(bt.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Action_node.HasEvents());
			return true;
		}
	}
}
