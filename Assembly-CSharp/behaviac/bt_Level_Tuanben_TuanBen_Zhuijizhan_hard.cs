using System;

namespace behaviac
{
	// Token: 0x02002B39 RID: 11065
	public static class bt_Level_Tuanben_TuanBen_Zhuijizhan_hard
	{
		// Token: 0x06013F81 RID: 81793 RVA: 0x005FEB14 File Offset: 0x005FCF14
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Level/Tuanben/TuanBen_Zhuijizhan_hard");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node3 condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node = new Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node3();
			condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node.SetClassNameString("Condition");
			condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node.SetId(3);
			sequence.AddChild(condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node.HasEvents());
			Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node1 condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node2 = new Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node1();
			condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node2.SetClassNameString("Condition");
			condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node2.SetId(1);
			sequence.AddChild(condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node2.HasEvents());
			Action_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node2 action_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node = new Action_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node2();
			action_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node.SetClassNameString("Action");
			action_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node.SetId(2);
			sequence.AddChild(action_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node.HasEvents());
			Assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node4 assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node = new Assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node4();
			assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node.SetClassNameString("Assignment");
			assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node.SetId(4);
			sequence.AddChild(assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
