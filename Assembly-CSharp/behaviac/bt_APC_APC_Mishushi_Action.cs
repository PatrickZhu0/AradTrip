﻿using System;

namespace behaviac
{
	// Token: 0x02001DCF RID: 7631
	public static class bt_APC_APC_Mishushi_Action
	{
		// Token: 0x06012556 RID: 75094 RVA: 0x0055A46C File Offset: 0x0055886C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("APC/APC_Mishushi_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(22);
			selector.AddChild(sequence);
			Condition_bt_APC_APC_Mishushi_Action_node2 condition_bt_APC_APC_Mishushi_Action_node = new Condition_bt_APC_APC_Mishushi_Action_node2();
			condition_bt_APC_APC_Mishushi_Action_node.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node.SetId(2);
			sequence.AddChild(condition_bt_APC_APC_Mishushi_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node.HasEvents());
			Condition_bt_APC_APC_Mishushi_Action_node10 condition_bt_APC_APC_Mishushi_Action_node2 = new Condition_bt_APC_APC_Mishushi_Action_node10();
			condition_bt_APC_APC_Mishushi_Action_node2.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node2.SetId(10);
			sequence.AddChild(condition_bt_APC_APC_Mishushi_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node2.HasEvents());
			Condition_bt_APC_APC_Mishushi_Action_node25 condition_bt_APC_APC_Mishushi_Action_node3 = new Condition_bt_APC_APC_Mishushi_Action_node25();
			condition_bt_APC_APC_Mishushi_Action_node3.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node3.SetId(25);
			sequence.AddChild(condition_bt_APC_APC_Mishushi_Action_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node3.HasEvents());
			Action_bt_APC_APC_Mishushi_Action_node4 action_bt_APC_APC_Mishushi_Action_node = new Action_bt_APC_APC_Mishushi_Action_node4();
			action_bt_APC_APC_Mishushi_Action_node.SetClassNameString("Action");
			action_bt_APC_APC_Mishushi_Action_node.SetId(4);
			sequence.AddChild(action_bt_APC_APC_Mishushi_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_APC_APC_Mishushi_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(53);
			selector.AddChild(sequence2);
			Condition_bt_APC_APC_Mishushi_Action_node54 condition_bt_APC_APC_Mishushi_Action_node4 = new Condition_bt_APC_APC_Mishushi_Action_node54();
			condition_bt_APC_APC_Mishushi_Action_node4.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node4.SetId(54);
			sequence2.AddChild(condition_bt_APC_APC_Mishushi_Action_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node4.HasEvents());
			Condition_bt_APC_APC_Mishushi_Action_node55 condition_bt_APC_APC_Mishushi_Action_node5 = new Condition_bt_APC_APC_Mishushi_Action_node55();
			condition_bt_APC_APC_Mishushi_Action_node5.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node5.SetId(55);
			sequence2.AddChild(condition_bt_APC_APC_Mishushi_Action_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node5.HasEvents());
			Condition_bt_APC_APC_Mishushi_Action_node56 condition_bt_APC_APC_Mishushi_Action_node6 = new Condition_bt_APC_APC_Mishushi_Action_node56();
			condition_bt_APC_APC_Mishushi_Action_node6.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node6.SetId(56);
			sequence2.AddChild(condition_bt_APC_APC_Mishushi_Action_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node6.HasEvents());
			Action_bt_APC_APC_Mishushi_Action_node57 action_bt_APC_APC_Mishushi_Action_node2 = new Action_bt_APC_APC_Mishushi_Action_node57();
			action_bt_APC_APC_Mishushi_Action_node2.SetClassNameString("Action");
			action_bt_APC_APC_Mishushi_Action_node2.SetId(57);
			sequence2.AddChild(action_bt_APC_APC_Mishushi_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_APC_APC_Mishushi_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(63);
			selector.AddChild(sequence3);
			Condition_bt_APC_APC_Mishushi_Action_node64 condition_bt_APC_APC_Mishushi_Action_node7 = new Condition_bt_APC_APC_Mishushi_Action_node64();
			condition_bt_APC_APC_Mishushi_Action_node7.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node7.SetId(64);
			sequence3.AddChild(condition_bt_APC_APC_Mishushi_Action_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node7.HasEvents());
			Condition_bt_APC_APC_Mishushi_Action_node65 condition_bt_APC_APC_Mishushi_Action_node8 = new Condition_bt_APC_APC_Mishushi_Action_node65();
			condition_bt_APC_APC_Mishushi_Action_node8.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node8.SetId(65);
			sequence3.AddChild(condition_bt_APC_APC_Mishushi_Action_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node8.HasEvents());
			Condition_bt_APC_APC_Mishushi_Action_node66 condition_bt_APC_APC_Mishushi_Action_node9 = new Condition_bt_APC_APC_Mishushi_Action_node66();
			condition_bt_APC_APC_Mishushi_Action_node9.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node9.SetId(66);
			sequence3.AddChild(condition_bt_APC_APC_Mishushi_Action_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node9.HasEvents());
			Action_bt_APC_APC_Mishushi_Action_node67 action_bt_APC_APC_Mishushi_Action_node3 = new Action_bt_APC_APC_Mishushi_Action_node67();
			action_bt_APC_APC_Mishushi_Action_node3.SetClassNameString("Action");
			action_bt_APC_APC_Mishushi_Action_node3.SetId(67);
			sequence3.AddChild(action_bt_APC_APC_Mishushi_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_APC_APC_Mishushi_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(87);
			selector.AddChild(sequence4);
			Condition_bt_APC_APC_Mishushi_Action_node88 condition_bt_APC_APC_Mishushi_Action_node10 = new Condition_bt_APC_APC_Mishushi_Action_node88();
			condition_bt_APC_APC_Mishushi_Action_node10.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node10.SetId(88);
			sequence4.AddChild(condition_bt_APC_APC_Mishushi_Action_node10);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node10.HasEvents());
			Condition_bt_APC_APC_Mishushi_Action_node89 condition_bt_APC_APC_Mishushi_Action_node11 = new Condition_bt_APC_APC_Mishushi_Action_node89();
			condition_bt_APC_APC_Mishushi_Action_node11.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node11.SetId(89);
			sequence4.AddChild(condition_bt_APC_APC_Mishushi_Action_node11);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node11.HasEvents());
			Condition_bt_APC_APC_Mishushi_Action_node90 condition_bt_APC_APC_Mishushi_Action_node12 = new Condition_bt_APC_APC_Mishushi_Action_node90();
			condition_bt_APC_APC_Mishushi_Action_node12.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node12.SetId(90);
			sequence4.AddChild(condition_bt_APC_APC_Mishushi_Action_node12);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node12.HasEvents());
			Action_bt_APC_APC_Mishushi_Action_node91 action_bt_APC_APC_Mishushi_Action_node4 = new Action_bt_APC_APC_Mishushi_Action_node91();
			action_bt_APC_APC_Mishushi_Action_node4.SetClassNameString("Action");
			action_bt_APC_APC_Mishushi_Action_node4.SetId(91);
			sequence4.AddChild(action_bt_APC_APC_Mishushi_Action_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_APC_APC_Mishushi_Action_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(41);
			selector.AddChild(sequence5);
			Condition_bt_APC_APC_Mishushi_Action_node42 condition_bt_APC_APC_Mishushi_Action_node13 = new Condition_bt_APC_APC_Mishushi_Action_node42();
			condition_bt_APC_APC_Mishushi_Action_node13.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node13.SetId(42);
			sequence5.AddChild(condition_bt_APC_APC_Mishushi_Action_node13);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node13.HasEvents());
			Condition_bt_APC_APC_Mishushi_Action_node44 condition_bt_APC_APC_Mishushi_Action_node14 = new Condition_bt_APC_APC_Mishushi_Action_node44();
			condition_bt_APC_APC_Mishushi_Action_node14.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node14.SetId(44);
			sequence5.AddChild(condition_bt_APC_APC_Mishushi_Action_node14);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node14.HasEvents());
			Condition_bt_APC_APC_Mishushi_Action_node46 condition_bt_APC_APC_Mishushi_Action_node15 = new Condition_bt_APC_APC_Mishushi_Action_node46();
			condition_bt_APC_APC_Mishushi_Action_node15.SetClassNameString("Condition");
			condition_bt_APC_APC_Mishushi_Action_node15.SetId(46);
			sequence5.AddChild(condition_bt_APC_APC_Mishushi_Action_node15);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_APC_APC_Mishushi_Action_node15.HasEvents());
			Action_bt_APC_APC_Mishushi_Action_node73 action_bt_APC_APC_Mishushi_Action_node5 = new Action_bt_APC_APC_Mishushi_Action_node73();
			action_bt_APC_APC_Mishushi_Action_node5.SetClassNameString("Action");
			action_bt_APC_APC_Mishushi_Action_node5.SetId(73);
			sequence5.AddChild(action_bt_APC_APC_Mishushi_Action_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_APC_APC_Mishushi_Action_node5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
