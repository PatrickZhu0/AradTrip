using System;

namespace behaviac
{
	// Token: 0x02003263 RID: 12899
	public static class bt_Monster_AI_Digongfuben_Digong_Shifa_Event
	{
		// Token: 0x06014D45 RID: 85317 RVA: 0x006463B0 File Offset: 0x006447B0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Digongfuben/Digong_Shifa_Event");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(9);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(10);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node1 condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node = new Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node1();
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node6 condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2 = new Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node6();
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node7 action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node = new Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node7();
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node.SetId(7);
			sequence.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node.HasEvents());
			Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2 assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node = new Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2();
			assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node.SetId(2);
			sequence.AddChild(assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Selector selector2 = new Selector();
			selector2.SetClassNameString("Selector");
			selector2.SetId(11);
			selector.AddChild(selector2);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(12);
			selector2.AddChild(sequence2);
			Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4 condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3 = new Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4();
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node14 condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4 = new Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node14();
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4.SetId(14);
			sequence2.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3 action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2 = new Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3();
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2.SetId(3);
			sequence2.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node15 action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3 = new Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node15();
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3.SetId(15);
			sequence2.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3.HasEvents());
			Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5 assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2 = new Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5();
			assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2.SetId(5);
			sequence2.AddChild(assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(13);
			selector2.AddChild(sequence3);
			Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node18 condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5 = new Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node18();
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5.SetId(18);
			sequence3.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node17 action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4 = new Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node17();
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4.SetId(17);
			sequence3.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4.HasEvents());
			Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node19 assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3 = new Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node19();
			assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3.SetId(19);
			sequence3.AddChild(assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node3.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | selector2.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(0);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node8 condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node6 = new Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node8();
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node6.SetId(8);
			sequence4.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node6);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node6.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node20 condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node7 = new Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node20();
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node7.SetId(20);
			sequence4.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node7);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node7.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node21 action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5 = new Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node21();
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5.SetId(21);
			sequence4.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5.HasEvents());
			Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node16 assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4 = new Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node16();
			assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4.SetId(16);
			sequence4.AddChild(assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
