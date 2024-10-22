﻿using System;

namespace behaviac
{
	// Token: 0x0200381F RID: 14367
	public static class bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4
	{
		// Token: 0x0601582D RID: 88109 RVA: 0x0067DB74 File Offset: 0x0067BF74
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_2_Zui_Zui_4");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node0 parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node = new Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node0();
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.SetId(0);
			bt.AddChild(parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node2 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node2.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node10 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node10();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.SetId(10);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node2 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node2.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.AddChild(sequence2);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3.SetId(9);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4.SetId(8);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node11 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node11();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5.SetId(11);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node19 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node19();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4.SetId(19);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node4.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6.SetId(7);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(12);
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.AddChild(sequence3);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node13 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node13();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5.SetId(13);
			sequence3.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node5.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node18 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node18();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6.SetId(18);
			sequence3.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node6.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node15 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node15();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7.SetId(15);
			sequence3.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node16 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node16();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8.SetId(16);
			sequence3.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node14 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node14();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9.SetId(14);
			sequence3.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node21 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node21();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7.SetId(21);
			sequence3.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node7.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node17 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node10 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node17();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node10.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node10.SetId(17);
			sequence3.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node10);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node10.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(22);
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.AddChild(sequence4);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node23 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node23();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8.SetId(23);
			sequence4.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node8.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node24 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node24();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9.SetId(24);
			sequence4.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node25 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node11 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node25();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node11.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node11.SetId(25);
			sequence4.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node11);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node11.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node.HasEvents());
			return true;
		}
	}
}
