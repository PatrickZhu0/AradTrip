using System;

namespace behaviac
{
	// Token: 0x02003243 RID: 12867
	public static class bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event
	{
		// Token: 0x06014D08 RID: 85256 RVA: 0x00645450 File Offset: 0x00643850
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Digongfuben/Digong_Baoxiang_Event");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(8);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4 condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node = new Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4();
			condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node6 condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2 = new Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node6();
			condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node1 condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3 = new Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node1();
			condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2 action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node = new Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2();
			action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node7 action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2 = new Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node7();
			action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2.SetId(7);
			sequence.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3 action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3 = new Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3();
			action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node3.HasEvents());
			Assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node5 assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node = new Assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node5();
			assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node.SetId(5);
			sequence.AddChild(assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(9);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node11 condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4 = new Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node11();
			condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4.SetId(11);
			sequence2.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node10 condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node5 = new Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node10();
			condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node5.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node5.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node12 action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4 = new Action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node12();
			action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4.SetId(12);
			sequence2.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4.HasEvents());
			Assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node13 assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2 = new Assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node13();
			assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2.SetId(13);
			sequence2.AddChild(assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
