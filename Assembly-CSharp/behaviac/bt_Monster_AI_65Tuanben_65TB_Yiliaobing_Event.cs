using System;

namespace behaviac
{
	// Token: 0x02002D26 RID: 11558
	public static class bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event
	{
		// Token: 0x06014337 RID: 82743 RVA: 0x006117DC File Offset: 0x0060FBDC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_Yiliaobing_Event");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node5 parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node = new Parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node5();
			parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.SetId(5);
			bt.AddChild(parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(6);
			parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node7 condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node = new Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node7();
			condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.SetId(7);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node8 action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node = new Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node8();
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(9);
			parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.AddChild(sequence2);
			Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node10 condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2 = new Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node10();
			condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node11 action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2 = new Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node11();
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2.SetId(11);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node0 action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3 = new Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node0();
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3.SetId(0);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(1);
			parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.AddChild(sequence3);
			Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2 condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3 = new Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node2();
			condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3.SetId(2);
			sequence3.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3 action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node4 = new Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3();
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node4.SetId(3);
			sequence3.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node4.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node4 action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node5 = new Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node4();
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node5.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node5.SetId(4);
			sequence3.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node5.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node.HasEvents());
			return true;
		}
	}
}
