﻿using System;

namespace behaviac
{
	// Token: 0x02003394 RID: 13204
	public static class bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event
	{
		// Token: 0x06014F85 RID: 85893 RVA: 0x00651088 File Offset: 0x0064F488
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GoblinKingdom/Juxingbaodan_idle_Event");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(4);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3 condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node = new Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3();
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node1 condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2 = new Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node1();
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node19 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node19();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3.SetId(19);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node20 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node4 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node20();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node4.SetId(20);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node4);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node4.HasEvents());
			Assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5 assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node = new Assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5();
			assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node.SetId(5);
			sequence.AddChild(assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node23 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node23();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5.SetId(23);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node21 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node21();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6.SetId(21);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node22 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node7 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node22();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node7.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node7.SetId(22);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node7);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node7.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(8);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node9 condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3 = new Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node9();
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3.SetId(9);
			sequence2.AddChild(condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node10 condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node4 = new Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node10();
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node4.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node4.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node7 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node8 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node7();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node8.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node8.SetId(7);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node8);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node8.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node12 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node9 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node12();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node9.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node9.SetId(12);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node9);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node9.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node24 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node10 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node24();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node10.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node10.SetId(24);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node10);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node10.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node25 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node11 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node25();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node11.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node11.SetId(25);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node11);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node11.HasEvents());
			Assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node13 assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2 = new Assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node13();
			assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2.SetId(13);
			sequence2.AddChild(assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node26 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node12 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node26();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node12.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node12.SetId(26);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node12);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node12.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node27 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node13 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node27();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node13.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node13.SetId(27);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node13);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node13.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node28 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node14 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node28();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node14.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node14.SetId(28);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node14);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node14.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(11);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node14 condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5 = new Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node14();
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5.SetId(14);
			sequence3.AddChild(condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node15 condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6 = new Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node15();
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6.SetId(15);
			sequence3.AddChild(condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node6.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node16 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node15 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node16();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node15.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node15.SetId(16);
			sequence3.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node15);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node15.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node17 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node16 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node17();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node16.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node16.SetId(17);
			sequence3.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node16);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node16.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node29 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node17 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node29();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node17.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node17.SetId(29);
			sequence3.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node17);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node17.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node30 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node18 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node30();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node18.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node18.SetId(30);
			sequence3.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node18);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node18.HasEvents());
			Assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node18 assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3 = new Assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node18();
			assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3.SetId(18);
			sequence3.AddChild(assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node31 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node19 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node31();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node19.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node19.SetId(31);
			sequence3.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node19);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node19.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node32 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node20 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node32();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node20.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node20.SetId(32);
			sequence3.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node20);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node20.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node33 action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node21 = new Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node33();
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node21.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node21.SetId(33);
			sequence3.AddChild(action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node21);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node21.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
