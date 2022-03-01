using System;

namespace behaviac
{
	// Token: 0x02002AE9 RID: 10985
	public static class bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level
	{
		// Token: 0x06013EE9 RID: 81641 RVA: 0x005FB78C File Offset: 0x005F9B8C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Level/Tuanben/TuanBen_Chap_2_Zui_Level");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node3 condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node = new Condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node3();
			condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node.SetClassNameString("Condition");
			condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node.SetId(3);
			sequence.AddChild(condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node.HasEvents());
			Condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node2 condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node2 = new Condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node2();
			condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node2.SetClassNameString("Condition");
			condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node2.SetId(2);
			sequence.AddChild(condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node2.HasEvents());
			Action_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node1 action_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node = new Action_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node1();
			action_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node.SetClassNameString("Action");
			action_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node.SetId(1);
			sequence.AddChild(action_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node.HasEvents());
			Assignment_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node4 assignment_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node = new Assignment_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node4();
			assignment_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node.SetClassNameString("Assignment");
			assignment_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node.SetId(4);
			sequence.AddChild(assignment_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
