using System;

namespace behaviac
{
	// Token: 0x02003297 RID: 12951
	public static class bt_Monster_AI_Digongfuben_Digong_Tishi4_Event
	{
		// Token: 0x06014DA8 RID: 85416 RVA: 0x00647F48 File Offset: 0x00646348
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Digongfuben/Digong_Tishi4_Event");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(1);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(3);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node11 condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node = new Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node11();
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node.SetId(11);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node12 condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node2 = new Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node12();
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node2.SetId(12);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node2.HasEvents());
			Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node13 assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node = new Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node13();
			assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node.SetId(13);
			sequence.AddChild(assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(0);
			selector.AddChild(sequence2);
			Selector selector2 = new Selector();
			selector2.SetClassNameString("Selector");
			selector2.SetId(14);
			sequence2.AddChild(selector2);
			Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node4 condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node3 = new Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node4();
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node3.SetId(4);
			selector2.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node3);
			selector2.SetHasEvents(selector2.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node3.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node15 condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node4 = new Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node15();
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node4.SetId(15);
			selector2.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node4);
			selector2.SetHasEvents(selector2.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node4.HasEvents());
			sequence2.SetHasEvents(sequence2.HasEvents() | selector2.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node6 condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node5 = new Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node6();
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node5.SetId(6);
			sequence2.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node5.HasEvents());
			Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node5 assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node2 = new Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node5();
			assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node2.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node2.SetId(5);
			sequence2.AddChild(assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(2);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node7 condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node6 = new Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node7();
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node6.SetId(7);
			sequence3.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node6.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node8 condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node7 = new Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node8();
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node7.SetId(8);
			sequence3.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node7.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node9 action_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node = new Action_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node9();
			action_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node.SetId(9);
			sequence3.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node.HasEvents());
			Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node10 assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node3 = new Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node10();
			assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node3.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node3.SetId(10);
			sequence3.AddChild(assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
