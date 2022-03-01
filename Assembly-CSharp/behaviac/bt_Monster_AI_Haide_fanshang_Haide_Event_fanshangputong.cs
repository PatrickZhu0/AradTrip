using System;

namespace behaviac
{
	// Token: 0x020033D8 RID: 13272
	public static class bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong
	{
		// Token: 0x06015006 RID: 86022 RVA: 0x00653CE8 File Offset: 0x006520E8
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Haide_fanshang/Haide_Event_fanshangputong");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node3 condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node = new Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node3();
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node.HasEvents());
			Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node4 condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2 = new Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node4();
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2.HasEvents());
			Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node5 condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node3 = new Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node5();
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node3.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node3.HasEvents());
			Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node6 action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node = new Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node6();
			action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node.SetClassNameString("Action");
			action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node.HasEvents());
			Assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node7 assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node = new Assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node7();
			assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node.SetId(7);
			sequence.AddChild(assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node9 condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node4 = new Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node9();
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node4.SetId(9);
			sequence2.AddChild(condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node4.HasEvents());
			Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node8 condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node5 = new Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node8();
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node5.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node5.HasEvents());
			Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node10 condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node6 = new Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node10();
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node6.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node6.HasEvents());
			Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node11 action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2 = new Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node11();
			action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2.SetId(11);
			sequence2.AddChild(action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2.HasEvents());
			Assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node12 assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2 = new Assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node12();
			assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2.SetId(12);
			sequence2.AddChild(assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
