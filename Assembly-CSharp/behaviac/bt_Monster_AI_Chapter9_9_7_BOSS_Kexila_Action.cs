﻿using System;

namespace behaviac
{
	// Token: 0x02003216 RID: 12822
	public static class bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action
	{
		// Token: 0x06014CB6 RID: 85174 RVA: 0x00643714 File Offset: 0x00641B14
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter9/9-7_BOSS_Kexila_Action");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7 parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node = new Parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7();
			parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.SetId(7);
			bt.AddChild(parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.AddChild(sequence);
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.HasEvents());
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(1);
			sequence.AddChild(selector);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(6);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node16 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node2 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node16();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node2.SetId(16);
			sequence2.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node2.HasEvents());
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node14 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node14();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3.SetId(14);
			sequence2.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3.HasEvents());
			Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8 action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node = new Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8();
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.SetId(8);
			sequence2.AddChild(action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(5);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node10 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node10();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4.SetId(10);
			sequence3.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4.HasEvents());
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node15 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node5 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node15();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node5.SetId(15);
			sequence3.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node5.HasEvents());
			Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node12 action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node2 = new Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node12();
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node2.SetId(12);
			sequence3.AddChild(action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node2);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(19);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node20 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node6 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node20();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node6.SetId(20);
			sequence4.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node6);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node6.HasEvents());
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node21 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node21();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7.SetId(21);
			sequence4.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7.HasEvents());
			Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node22 action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3 = new Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node22();
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3.SetId(22);
			sequence4.AddChild(action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(23);
			selector.AddChild(sequence5);
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node24 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node24();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8.SetId(24);
			sequence5.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8.HasEvents());
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node25 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node9 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node25();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node9.SetId(25);
			sequence5.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node9);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node9.HasEvents());
			Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node26 action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4 = new Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node26();
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4.SetId(26);
			sequence5.AddChild(action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selector.HasEvents());
			parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.SetHasEvents(parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.HasEvents() | sequence.HasEvents());
			Sequence sequence6 = new Sequence();
			sequence6.SetClassNameString("Sequence");
			sequence6.SetId(9);
			parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.AddChild(sequence6);
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node10 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node4();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node10.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node10.SetId(4);
			sequence6.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node10);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node10.HasEvents());
			Selector selector2 = new Selector();
			selector2.SetClassNameString("Selector");
			selector2.SetId(2);
			sequence6.AddChild(selector2);
			Sequence sequence7 = new Sequence();
			sequence7.SetClassNameString("Sequence");
			sequence7.SetId(35);
			selector2.AddChild(sequence7);
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node36 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node11 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node36();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node11.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node11.SetId(36);
			sequence7.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node11);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node11.HasEvents());
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node38 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node12 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node38();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node12.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node12.SetId(38);
			sequence7.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node12);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node12.HasEvents());
			Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node37 action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node5 = new Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node37();
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node5.SetId(37);
			sequence7.AddChild(action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node5);
			sequence7.SetHasEvents(sequence7.HasEvents() | action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node5.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence7.HasEvents());
			Sequence sequence8 = new Sequence();
			sequence8.SetClassNameString("Sequence");
			sequence8.SetId(39);
			selector2.AddChild(sequence8);
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node40 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node13 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node40();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node13.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node13.SetId(40);
			sequence8.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node13);
			sequence8.SetHasEvents(sequence8.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node13.HasEvents());
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node42 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node14 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node42();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node14.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node14.SetId(42);
			sequence8.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node14);
			sequence8.SetHasEvents(sequence8.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node14.HasEvents());
			Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node41 action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node6 = new Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node41();
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node6.SetId(41);
			sequence8.AddChild(action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node6);
			sequence8.SetHasEvents(sequence8.HasEvents() | action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node6.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence8.HasEvents());
			Sequence sequence9 = new Sequence();
			sequence9.SetClassNameString("Sequence");
			sequence9.SetId(51);
			selector2.AddChild(sequence9);
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node52 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node15 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node52();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node15.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node15.SetId(52);
			sequence9.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node15);
			sequence9.SetHasEvents(sequence9.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node15.HasEvents());
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node54 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node16 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node54();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node16.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node16.SetId(54);
			sequence9.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node16);
			sequence9.SetHasEvents(sequence9.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node16.HasEvents());
			Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node53 action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7 = new Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node53();
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7.SetId(53);
			sequence9.AddChild(action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7);
			sequence9.SetHasEvents(sequence9.HasEvents() | action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence9.HasEvents());
			Sequence sequence10 = new Sequence();
			sequence10.SetClassNameString("Sequence");
			sequence10.SetId(11);
			selector2.AddChild(sequence10);
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node13 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node17 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node13();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node17.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node17.SetId(13);
			sequence10.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node17);
			sequence10.SetHasEvents(sequence10.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node17.HasEvents());
			Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node17 condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node18 = new Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node17();
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node18.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node18.SetId(17);
			sequence10.AddChild(condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node18);
			sequence10.SetHasEvents(sequence10.HasEvents() | condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node18.HasEvents());
			Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node18 action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8 = new Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node18();
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8.SetId(18);
			sequence10.AddChild(action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8);
			sequence10.SetHasEvents(sequence10.HasEvents() | action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node8.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence10.HasEvents());
			sequence6.SetHasEvents(sequence6.HasEvents() | selector2.HasEvents());
			parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.SetHasEvents(parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.HasEvents() | sequence6.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node.HasEvents());
			return true;
		}
	}
}
