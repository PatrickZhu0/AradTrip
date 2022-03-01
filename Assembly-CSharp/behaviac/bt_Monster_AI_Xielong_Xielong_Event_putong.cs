using System;

namespace behaviac
{
	// Token: 0x02003E4C RID: 15948
	public static class bt_Monster_AI_Xielong_Xielong_Event_putong
	{
		// Token: 0x0601641D RID: 91165 RVA: 0x006BA99C File Offset: 0x006B8D9C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Xielong/Xielong_Event_putong");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node3 condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node = new Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node3();
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node.HasEvents());
			Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node19 condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node2 = new Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node19();
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node2.SetId(19);
			sequence.AddChild(condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node2.HasEvents());
			Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node4 condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node3 = new Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node4();
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node3.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node3.HasEvents());
			Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node5 condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node4 = new Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node5();
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node4.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node4);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node4.HasEvents());
			Action_bt_Monster_AI_Xielong_Xielong_Event_putong_node6 action_bt_Monster_AI_Xielong_Xielong_Event_putong_node = new Action_bt_Monster_AI_Xielong_Xielong_Event_putong_node6();
			action_bt_Monster_AI_Xielong_Xielong_Event_putong_node.SetClassNameString("Action");
			action_bt_Monster_AI_Xielong_Xielong_Event_putong_node.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_Xielong_Xielong_Event_putong_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Xielong_Xielong_Event_putong_node.HasEvents());
			Assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node7 assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node = new Assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node7();
			assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node.SetId(7);
			sequence.AddChild(assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node8 condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node5 = new Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node8();
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node5.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node5.HasEvents());
			Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node20 condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node6 = new Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node20();
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node6.SetId(20);
			sequence2.AddChild(condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node6.HasEvents());
			Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node9 condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node7 = new Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node9();
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node7.SetId(9);
			sequence2.AddChild(condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node7);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node7.HasEvents());
			Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node10 condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node8 = new Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node10();
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node8.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node8);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node8.HasEvents());
			Action_bt_Monster_AI_Xielong_Xielong_Event_putong_node11 action_bt_Monster_AI_Xielong_Xielong_Event_putong_node2 = new Action_bt_Monster_AI_Xielong_Xielong_Event_putong_node11();
			action_bt_Monster_AI_Xielong_Xielong_Event_putong_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Xielong_Xielong_Event_putong_node2.SetId(11);
			sequence2.AddChild(action_bt_Monster_AI_Xielong_Xielong_Event_putong_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Xielong_Xielong_Event_putong_node2.HasEvents());
			Assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node12 assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node2 = new Assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node12();
			assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node2.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node2.SetId(12);
			sequence2.AddChild(assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(13);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node14 condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node9 = new Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node14();
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node9.SetId(14);
			sequence3.AddChild(condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node9.HasEvents());
			Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node15 condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node10 = new Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node15();
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node10.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node10.SetId(15);
			sequence3.AddChild(condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node10);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node10.HasEvents());
			Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node16 condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node11 = new Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node16();
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node11.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node11.SetId(16);
			sequence3.AddChild(condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node11);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node11.HasEvents());
			Action_bt_Monster_AI_Xielong_Xielong_Event_putong_node17 action_bt_Monster_AI_Xielong_Xielong_Event_putong_node3 = new Action_bt_Monster_AI_Xielong_Xielong_Event_putong_node17();
			action_bt_Monster_AI_Xielong_Xielong_Event_putong_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Xielong_Xielong_Event_putong_node3.SetId(17);
			sequence3.AddChild(action_bt_Monster_AI_Xielong_Xielong_Event_putong_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Xielong_Xielong_Event_putong_node3.HasEvents());
			Assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node18 assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node3 = new Assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node18();
			assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node3.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node3.SetId(18);
			sequence3.AddChild(assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | assignment_bt_Monster_AI_Xielong_Xielong_Event_putong_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
