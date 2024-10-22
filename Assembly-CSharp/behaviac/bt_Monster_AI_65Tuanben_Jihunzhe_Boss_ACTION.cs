﻿using System;

namespace behaviac
{
	// Token: 0x02002F19 RID: 12057
	public static class bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION
	{
		// Token: 0x06014709 RID: 83721 RVA: 0x00625DF0 File Offset: 0x006241F0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/Jihunzhe_Boss_ACTION");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(16);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(6);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node36 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node36();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node.SetId(36);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node22 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node22();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2.SetId(22);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node3 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node3.SetId(7);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node3.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node8 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node8();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node26 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2 = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node26();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2.SetId(26);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(3);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node85 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node85();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4.SetId(85);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node35 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node35();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5.SetId(35);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node6 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node6.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node6.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node3 = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node3.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node3.SetId(5);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(9);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node11 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node11();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7.SetId(11);
			sequence3.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node15 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node8 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node15();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node8.SetId(15);
			sequence3.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node8.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node13 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4 = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node13();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4.SetId(13);
			sequence3.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(10);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node12 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node9 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node12();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node9.SetId(12);
			sequence4.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node9);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node9.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node21 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node10 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node21();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node10.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node10.SetId(21);
			sequence4.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node10);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node10.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node14 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5 = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node14();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5.SetId(14);
			sequence4.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(0);
			selector.AddChild(sequence5);
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node1 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node11 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node1();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node11.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node11.SetId(1);
			sequence5.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node11);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node11.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node23 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node12 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node23();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node12.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node12.SetId(23);
			sequence5.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node12);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node12.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node6 = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node2();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node6.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node6.SetId(2);
			sequence5.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node6);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node6.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			Sequence sequence6 = new Sequence();
			sequence6.SetClassNameString("Sequence");
			sequence6.SetId(17);
			selector.AddChild(sequence6);
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node18 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node13 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node18();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node13.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node13.SetId(18);
			sequence6.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node13);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node13.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node19 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node14 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node19();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node14.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node14.SetId(19);
			sequence6.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node14);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node14.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node20 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7 = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node20();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7.SetId(20);
			sequence6.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7);
			sequence6.SetHasEvents(sequence6.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node7.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence6.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
