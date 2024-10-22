﻿using System;

namespace behaviac
{
	// Token: 0x02002263 RID: 8803
	public static class bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action
	{
		// Token: 0x06012E4E RID: 77390 RVA: 0x00591EFC File Offset: 0x005902FC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("AutoFight/AutoFight_Fight_Swordman_Axiuluo_Normal_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(3);
			selector.AddChild(sequence);
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node.SetId(6);
			sequence.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2.SetId(5);
			sequence.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node3 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node3.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node3.SetId(4);
			sequence.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node3.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node9 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node9();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4.SetId(9);
			sequence.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node8 action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node = new Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node8();
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node.SetId(8);
			sequence.AddChild(action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(10);
			selector.AddChild(sequence2);
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node11 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node11();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5.SetId(11);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node15 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node15();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6.SetId(15);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node16 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node7 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node16();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node7.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node7.SetId(16);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node7);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node7.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node17 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node8 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node17();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node8.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node8.SetId(17);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node8);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node8.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node18 action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2 = new Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node18();
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2.SetId(18);
			sequence2.AddChild(action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(29);
			selector.AddChild(sequence3);
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node30 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node9 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node30();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node9.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node9.SetId(30);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node9.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node31 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node10 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node31();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node10.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node10.SetId(31);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node10);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node10.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node32 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node11 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node32();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node11.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node11.SetId(32);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node11);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node11.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node33 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node12 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node33();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node12.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node12.SetId(33);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node12);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node12.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node34 action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node3 = new Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node34();
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node3.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node3.SetId(34);
			sequence3.AddChild(action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(52);
			selector.AddChild(sequence4);
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node53 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node13 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node53();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node13.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node13.SetId(53);
			sequence4.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node13);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node13.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node54 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node14 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node54();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node14.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node14.SetId(54);
			sequence4.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node14);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node14.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node55 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node15 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node55();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node15.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node15.SetId(55);
			sequence4.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node15);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node15.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node56 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node16 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node56();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node16.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node16.SetId(56);
			sequence4.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node16);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node16.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node57 action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4 = new Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node57();
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4.SetId(57);
			sequence4.AddChild(action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(58);
			selector.AddChild(sequence5);
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node59 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node17 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node59();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node17.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node17.SetId(59);
			sequence5.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node17);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node17.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node60 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node18 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node60();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node18.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node18.SetId(60);
			sequence5.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node18);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node18.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node61 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node19 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node61();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node19.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node19.SetId(61);
			sequence5.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node19);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node19.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node62 action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5 = new Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node62();
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5.SetId(62);
			sequence5.AddChild(action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			Sequence sequence6 = new Sequence();
			sequence6.SetClassNameString("Sequence");
			sequence6.SetId(19);
			selector.AddChild(sequence6);
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node20 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node20 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node20();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node20.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node20.SetId(20);
			sequence6.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node20);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node20.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node21 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node21 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node21();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node21.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node21.SetId(21);
			sequence6.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node21);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node21.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node27 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node22 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node27();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node22.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node22.SetId(27);
			sequence6.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node22);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node22.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node28 action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6 = new Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node28();
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6.SetId(28);
			sequence6.AddChild(action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6);
			sequence6.SetHasEvents(sequence6.HasEvents() | action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence6.HasEvents());
			Sequence sequence7 = new Sequence();
			sequence7.SetClassNameString("Sequence");
			sequence7.SetId(7);
			selector.AddChild(sequence7);
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node12 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node23 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node12();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node23.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node23.SetId(12);
			sequence7.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node23);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node23.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node1 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node24 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node1();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node24.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node24.SetId(1);
			sequence7.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node24);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node24.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node13 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node25 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node13();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node25.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node25.SetId(13);
			sequence7.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node25);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node25.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node14 condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node26 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node14();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node26.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node26.SetId(14);
			sequence7.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node26);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node26.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2 action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node7 = new Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node2();
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node7.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node7.SetId(2);
			sequence7.AddChild(action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node7);
			sequence7.SetHasEvents(sequence7.HasEvents() | action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node7.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence7.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
