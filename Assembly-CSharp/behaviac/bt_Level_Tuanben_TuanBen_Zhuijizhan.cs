using System;

namespace behaviac
{
	// Token: 0x02002B34 RID: 11060
	public static class bt_Level_Tuanben_TuanBen_Zhuijizhan
	{
		// Token: 0x06013F78 RID: 81784 RVA: 0x005FE900 File Offset: 0x005FCD00
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Level/Tuanben/TuanBen_Zhuijizhan");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node3 condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node = new Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node3();
			condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node.SetClassNameString("Condition");
			condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node.SetId(3);
			sequence.AddChild(condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node.HasEvents());
			Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node1 condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node2 = new Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node1();
			condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node2.SetClassNameString("Condition");
			condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node2.SetId(1);
			sequence.AddChild(condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node2.HasEvents());
			Action_bt_Level_Tuanben_TuanBen_Zhuijizhan_node2 action_bt_Level_Tuanben_TuanBen_Zhuijizhan_node = new Action_bt_Level_Tuanben_TuanBen_Zhuijizhan_node2();
			action_bt_Level_Tuanben_TuanBen_Zhuijizhan_node.SetClassNameString("Action");
			action_bt_Level_Tuanben_TuanBen_Zhuijizhan_node.SetId(2);
			sequence.AddChild(action_bt_Level_Tuanben_TuanBen_Zhuijizhan_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Level_Tuanben_TuanBen_Zhuijizhan_node.HasEvents());
			Assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_node4 assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_node = new Assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_node4();
			assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_node.SetClassNameString("Assignment");
			assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_node.SetId(4);
			sequence.AddChild(assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
