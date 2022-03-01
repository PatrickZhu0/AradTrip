using System;

namespace behaviac
{
	// Token: 0x02002BC9 RID: 11209
	public static class bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event
	{
		// Token: 0x06014094 RID: 82068 RVA: 0x00604970 File Offset: 0x00602D70
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_Saiche_huoyaotong_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node0 condition_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node = new Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node0();
			condition_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node3 action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node = new Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node3();
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node2 action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node2 = new Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node2();
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
