﻿using System;

namespace behaviac
{
	// Token: 0x02003614 RID: 13844
	public static class bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action
	{
		// Token: 0x0601544E RID: 87118 RVA: 0x00669050 File Offset: 0x00667450
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Chongwanglugu/Monster_Chongwanglugu_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(12);
			selector.AddChild(sequence);
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node30 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node30();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node.SetId(30);
			sequence.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(11);
			sequence.AddChild(sequence2);
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node37 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node37();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node.SetId(37);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node13 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node13();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2.SetId(13);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2.HasEvents());
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node15 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2 = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node15();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2.SetId(15);
			sequence2.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(16);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3.SetId(7);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node17 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node17();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4.SetId(17);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node18 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node18();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5.SetId(18);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node19 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node6 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node19();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node6.SetId(19);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node6.HasEvents());
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node20 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3 = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node20();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3.SetId(20);
			sequence3.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(29);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node36 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node36();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7.SetId(36);
			sequence4.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node43 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node43();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8.SetId(43);
			sequence4.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node44 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node44();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9.SetId(44);
			sequence4.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9.HasEvents());
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node45 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4 = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node45();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4.SetId(45);
			sequence4.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(21);
			selector.AddChild(sequence5);
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node22 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node22();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10.SetId(22);
			sequence5.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node23 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node11 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node23();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node11.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node11.SetId(23);
			sequence5.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node11);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node11.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node24 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node12 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node24();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node12.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node12.SetId(24);
			sequence5.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node12);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node12.HasEvents());
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node25 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5 = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node25();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5.SetId(25);
			sequence5.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			Sequence sequence6 = new Sequence();
			sequence6.SetClassNameString("Sequence");
			sequence6.SetId(1);
			selector.AddChild(sequence6);
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node13 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node2();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node13.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node13.SetId(2);
			sequence6.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node13);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node13.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node14 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node14.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node14.SetId(3);
			sequence6.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node14);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node14.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node15 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node4();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node15.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node15.SetId(4);
			sequence6.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node15);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node15.HasEvents());
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node6 = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node5();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node6.SetId(5);
			sequence6.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node6);
			sequence6.SetHasEvents(sequence6.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node6.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence6.HasEvents());
			Sequence sequence7 = new Sequence();
			sequence7.SetClassNameString("Sequence");
			sequence7.SetId(6);
			selector.AddChild(sequence7);
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node28 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node16 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node28();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node16.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node16.SetId(28);
			sequence7.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node16);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node16.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node17 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node17.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node17.SetId(10);
			sequence7.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node17);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node17.HasEvents());
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7 = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7.SetId(8);
			sequence7.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7);
			sequence7.SetHasEvents(sequence7.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node7.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node14 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node18 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node14();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node18.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node18.SetId(14);
			sequence7.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node18);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node18.HasEvents());
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node27 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8 = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node27();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8.SetId(27);
			sequence7.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8);
			sequence7.SetHasEvents(sequence7.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node8.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence7.HasEvents());
			Sequence sequence8 = new Sequence();
			sequence8.SetClassNameString("Sequence");
			sequence8.SetId(38);
			selector.AddChild(sequence8);
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node19 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node19.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node19.SetId(9);
			sequence8.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node19);
			sequence8.SetHasEvents(sequence8.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node19.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node26 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node20 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node26();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node20.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node20.SetId(26);
			sequence8.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node20);
			sequence8.SetHasEvents(sequence8.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node20.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node40 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node21 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node40();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node21.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node21.SetId(40);
			sequence8.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node21);
			sequence8.SetHasEvents(sequence8.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node21.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node41 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node22 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node41();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node22.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node22.SetId(41);
			sequence8.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node22);
			sequence8.SetHasEvents(sequence8.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node22.HasEvents());
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node42 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9 = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node42();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9.SetId(42);
			sequence8.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9);
			sequence8.SetHasEvents(sequence8.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node9.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence8.HasEvents());
			Sequence sequence9 = new Sequence();
			sequence9.SetClassNameString("Sequence");
			sequence9.SetId(31);
			selector.AddChild(sequence9);
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node32 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node23 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node32();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node23.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node23.SetId(32);
			sequence9.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node23);
			sequence9.SetHasEvents(sequence9.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node23.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node33 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node24 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node33();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node24.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node24.SetId(33);
			sequence9.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node24);
			sequence9.SetHasEvents(sequence9.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node24.HasEvents());
			Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node34 condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node25 = new Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node34();
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node25.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node25.SetId(34);
			sequence9.AddChild(condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node25);
			sequence9.SetHasEvents(sequence9.HasEvents() | condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node25.HasEvents());
			Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node35 action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10 = new Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node35();
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10.SetId(35);
			sequence9.AddChild(action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10);
			sequence9.SetHasEvents(sequence9.HasEvents() | action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence9.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
