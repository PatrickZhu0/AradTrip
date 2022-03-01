using System;

namespace behaviac
{
	// Token: 0x02002ADA RID: 10970
	public static class bt_Level_65Tuanben_GongchengGuai
	{
		// Token: 0x06013ECD RID: 81613 RVA: 0x005FB000 File Offset: 0x005F9400
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Level/65Tuanben/GongchengGuai");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Level_65Tuanben_GongchengGuai_node3 condition_bt_Level_65Tuanben_GongchengGuai_node = new Condition_bt_Level_65Tuanben_GongchengGuai_node3();
			condition_bt_Level_65Tuanben_GongchengGuai_node.SetClassNameString("Condition");
			condition_bt_Level_65Tuanben_GongchengGuai_node.SetId(3);
			sequence.AddChild(condition_bt_Level_65Tuanben_GongchengGuai_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Level_65Tuanben_GongchengGuai_node.HasEvents());
			Action_bt_Level_65Tuanben_GongchengGuai_node2 action_bt_Level_65Tuanben_GongchengGuai_node = new Action_bt_Level_65Tuanben_GongchengGuai_node2();
			action_bt_Level_65Tuanben_GongchengGuai_node.SetClassNameString("Action");
			action_bt_Level_65Tuanben_GongchengGuai_node.SetId(2);
			sequence.AddChild(action_bt_Level_65Tuanben_GongchengGuai_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Level_65Tuanben_GongchengGuai_node.HasEvents());
			Assignment_bt_Level_65Tuanben_GongchengGuai_node4 assignment_bt_Level_65Tuanben_GongchengGuai_node = new Assignment_bt_Level_65Tuanben_GongchengGuai_node4();
			assignment_bt_Level_65Tuanben_GongchengGuai_node.SetClassNameString("Assignment");
			assignment_bt_Level_65Tuanben_GongchengGuai_node.SetId(4);
			sequence.AddChild(assignment_bt_Level_65Tuanben_GongchengGuai_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Level_65Tuanben_GongchengGuai_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
