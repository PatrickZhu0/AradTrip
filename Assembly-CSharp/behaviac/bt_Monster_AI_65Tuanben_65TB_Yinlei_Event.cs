using System;

namespace behaviac
{
	// Token: 0x02002D33 RID: 11571
	public static class bt_Monster_AI_65Tuanben_65TB_Yinlei_Event
	{
		// Token: 0x0601434E RID: 82766 RVA: 0x006120E8 File Offset: 0x006104E8
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_Yinlei_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node3 action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node = new Action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node3();
			action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node2 action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node2 = new Action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node2();
			action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
