using System;

namespace behaviac
{
	// Token: 0x02003733 RID: 14131
	public static class bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu
	{
		// Token: 0x06015672 RID: 87666 RVA: 0x00674E20 File Offset: 0x00673220
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Niutou_tongshuai/Niutou_tongshuai_Event_jiasu");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node1 action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node = new Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node1();
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node.HasEvents());
			Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2 condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node = new Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2();
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node.HasEvents());
			Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3 action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2 = new Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3();
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2.HasEvents());
			Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4 action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3 = new Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4();
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3.HasEvents());
			Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5 action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4 = new Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5();
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4.SetId(5);
			sequence.AddChild(action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4.HasEvents());
			Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6 action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5 = new Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6();
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5.HasEvents());
			Assignment_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node7 assignment_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node = new Assignment_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node7();
			assignment_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node.SetId(7);
			sequence.AddChild(assignment_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node.HasEvents());
			Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node8 condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2 = new Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node8();
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2.SetId(8);
			sequence.AddChild(condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2.HasEvents());
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(9);
			sequence.AddChild(selector);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(10);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node14 condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3 = new Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node14();
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3.SetId(14);
			sequence2.AddChild(condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3.HasEvents());
			Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node15 action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6 = new Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node15();
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6.SetId(15);
			sequence2.AddChild(action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(11);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node12 condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4 = new Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node12();
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4.SetId(12);
			sequence3.AddChild(condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node4.HasEvents());
			Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node13 action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node7 = new Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node13();
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node7.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node7.SetId(13);
			sequence3.AddChild(action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node7.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(16);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node17 condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5 = new Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node17();
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5.SetId(17);
			sequence4.AddChild(condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node5.HasEvents());
			Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node18 action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node8 = new Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node18();
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node8.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node8.SetId(18);
			sequence4.AddChild(action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node8);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node8.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(19);
			selector.AddChild(sequence5);
			Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node20 condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6 = new Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node20();
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6.SetId(20);
			sequence5.AddChild(condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node6.HasEvents());
			Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node21 action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node9 = new Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node21();
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node9.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node9.SetId(21);
			sequence5.AddChild(action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node9);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node9.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selector.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
