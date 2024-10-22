﻿using System;

namespace behaviac
{
	// Token: 0x02002A08 RID: 10760
	public static class bt_BOSS_BOSS20_DestinationSelect
	{
		// Token: 0x06013D42 RID: 81218 RVA: 0x005EF438 File Offset: 0x005ED838
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("BOSS/BOSS20_DestinationSelect");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_BOSS_BOSS20_DestinationSelect_node2 condition_bt_BOSS_BOSS20_DestinationSelect_node = new Condition_bt_BOSS_BOSS20_DestinationSelect_node2();
			condition_bt_BOSS_BOSS20_DestinationSelect_node.SetClassNameString("Condition");
			condition_bt_BOSS_BOSS20_DestinationSelect_node.SetId(2);
			sequence.AddChild(condition_bt_BOSS_BOSS20_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_BOSS_BOSS20_DestinationSelect_node.HasEvents());
			Condition_bt_BOSS_BOSS20_DestinationSelect_node3 condition_bt_BOSS_BOSS20_DestinationSelect_node2 = new Condition_bt_BOSS_BOSS20_DestinationSelect_node3();
			condition_bt_BOSS_BOSS20_DestinationSelect_node2.SetClassNameString("Condition");
			condition_bt_BOSS_BOSS20_DestinationSelect_node2.SetId(3);
			sequence.AddChild(condition_bt_BOSS_BOSS20_DestinationSelect_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_BOSS_BOSS20_DestinationSelect_node2.HasEvents());
			Action_bt_BOSS_BOSS20_DestinationSelect_node4 action_bt_BOSS_BOSS20_DestinationSelect_node = new Action_bt_BOSS_BOSS20_DestinationSelect_node4();
			action_bt_BOSS_BOSS20_DestinationSelect_node.SetClassNameString("Action");
			action_bt_BOSS_BOSS20_DestinationSelect_node.SetId(4);
			sequence.AddChild(action_bt_BOSS_BOSS20_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_BOSS_BOSS20_DestinationSelect_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(5);
			selector.AddChild(sequence2);
			Condition_bt_BOSS_BOSS20_DestinationSelect_node6 condition_bt_BOSS_BOSS20_DestinationSelect_node3 = new Condition_bt_BOSS_BOSS20_DestinationSelect_node6();
			condition_bt_BOSS_BOSS20_DestinationSelect_node3.SetClassNameString("Condition");
			condition_bt_BOSS_BOSS20_DestinationSelect_node3.SetId(6);
			sequence2.AddChild(condition_bt_BOSS_BOSS20_DestinationSelect_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_BOSS_BOSS20_DestinationSelect_node3.HasEvents());
			Selector selector2 = new Selector();
			selector2.SetClassNameString("Selector");
			selector2.SetId(17);
			sequence2.AddChild(selector2);
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(7);
			selector2.AddChild(sequence3);
			Condition_bt_BOSS_BOSS20_DestinationSelect_node8 condition_bt_BOSS_BOSS20_DestinationSelect_node4 = new Condition_bt_BOSS_BOSS20_DestinationSelect_node8();
			condition_bt_BOSS_BOSS20_DestinationSelect_node4.SetClassNameString("Condition");
			condition_bt_BOSS_BOSS20_DestinationSelect_node4.SetId(8);
			sequence3.AddChild(condition_bt_BOSS_BOSS20_DestinationSelect_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_BOSS_BOSS20_DestinationSelect_node4.HasEvents());
			Selector selector3 = new Selector();
			selector3.SetClassNameString("Selector");
			selector3.SetId(9);
			sequence3.AddChild(selector3);
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(10);
			selector3.AddChild(sequence4);
			Condition_bt_BOSS_BOSS20_DestinationSelect_node11 condition_bt_BOSS_BOSS20_DestinationSelect_node5 = new Condition_bt_BOSS_BOSS20_DestinationSelect_node11();
			condition_bt_BOSS_BOSS20_DestinationSelect_node5.SetClassNameString("Condition");
			condition_bt_BOSS_BOSS20_DestinationSelect_node5.SetId(11);
			sequence4.AddChild(condition_bt_BOSS_BOSS20_DestinationSelect_node5);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_BOSS_BOSS20_DestinationSelect_node5.HasEvents());
			Action_bt_BOSS_BOSS20_DestinationSelect_node12 action_bt_BOSS_BOSS20_DestinationSelect_node2 = new Action_bt_BOSS_BOSS20_DestinationSelect_node12();
			action_bt_BOSS_BOSS20_DestinationSelect_node2.SetClassNameString("Action");
			action_bt_BOSS_BOSS20_DestinationSelect_node2.SetId(12);
			sequence4.AddChild(action_bt_BOSS_BOSS20_DestinationSelect_node2);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_BOSS_BOSS20_DestinationSelect_node2.HasEvents());
			selector3.SetHasEvents(selector3.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(13);
			selector3.AddChild(sequence5);
			Condition_bt_BOSS_BOSS20_DestinationSelect_node14 condition_bt_BOSS_BOSS20_DestinationSelect_node6 = new Condition_bt_BOSS_BOSS20_DestinationSelect_node14();
			condition_bt_BOSS_BOSS20_DestinationSelect_node6.SetClassNameString("Condition");
			condition_bt_BOSS_BOSS20_DestinationSelect_node6.SetId(14);
			sequence5.AddChild(condition_bt_BOSS_BOSS20_DestinationSelect_node6);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_BOSS_BOSS20_DestinationSelect_node6.HasEvents());
			Action_bt_BOSS_BOSS20_DestinationSelect_node15 action_bt_BOSS_BOSS20_DestinationSelect_node3 = new Action_bt_BOSS_BOSS20_DestinationSelect_node15();
			action_bt_BOSS_BOSS20_DestinationSelect_node3.SetClassNameString("Action");
			action_bt_BOSS_BOSS20_DestinationSelect_node3.SetId(15);
			sequence5.AddChild(action_bt_BOSS_BOSS20_DestinationSelect_node3);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_BOSS_BOSS20_DestinationSelect_node3.HasEvents());
			selector3.SetHasEvents(selector3.HasEvents() | sequence5.HasEvents());
			Sequence sequence6 = new Sequence();
			sequence6.SetClassNameString("Sequence");
			sequence6.SetId(16);
			selector3.AddChild(sequence6);
			Action_bt_BOSS_BOSS20_DestinationSelect_node18 action_bt_BOSS_BOSS20_DestinationSelect_node4 = new Action_bt_BOSS_BOSS20_DestinationSelect_node18();
			action_bt_BOSS_BOSS20_DestinationSelect_node4.SetClassNameString("Action");
			action_bt_BOSS_BOSS20_DestinationSelect_node4.SetId(18);
			sequence6.AddChild(action_bt_BOSS_BOSS20_DestinationSelect_node4);
			sequence6.SetHasEvents(sequence6.HasEvents() | action_bt_BOSS_BOSS20_DestinationSelect_node4.HasEvents());
			selector3.SetHasEvents(selector3.HasEvents() | sequence6.HasEvents());
			sequence3.SetHasEvents(sequence3.HasEvents() | selector3.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence3.HasEvents());
			Selector selector4 = new Selector();
			selector4.SetClassNameString("Selector");
			selector4.SetId(19);
			selector2.AddChild(selector4);
			Sequence sequence7 = new Sequence();
			sequence7.SetClassNameString("Sequence");
			sequence7.SetId(20);
			selector4.AddChild(sequence7);
			Condition_bt_BOSS_BOSS20_DestinationSelect_node21 condition_bt_BOSS_BOSS20_DestinationSelect_node7 = new Condition_bt_BOSS_BOSS20_DestinationSelect_node21();
			condition_bt_BOSS_BOSS20_DestinationSelect_node7.SetClassNameString("Condition");
			condition_bt_BOSS_BOSS20_DestinationSelect_node7.SetId(21);
			sequence7.AddChild(condition_bt_BOSS_BOSS20_DestinationSelect_node7);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_BOSS_BOSS20_DestinationSelect_node7.HasEvents());
			Action_bt_BOSS_BOSS20_DestinationSelect_node22 action_bt_BOSS_BOSS20_DestinationSelect_node5 = new Action_bt_BOSS_BOSS20_DestinationSelect_node22();
			action_bt_BOSS_BOSS20_DestinationSelect_node5.SetClassNameString("Action");
			action_bt_BOSS_BOSS20_DestinationSelect_node5.SetId(22);
			sequence7.AddChild(action_bt_BOSS_BOSS20_DestinationSelect_node5);
			sequence7.SetHasEvents(sequence7.HasEvents() | action_bt_BOSS_BOSS20_DestinationSelect_node5.HasEvents());
			selector4.SetHasEvents(selector4.HasEvents() | sequence7.HasEvents());
			Sequence sequence8 = new Sequence();
			sequence8.SetClassNameString("Sequence");
			sequence8.SetId(23);
			selector4.AddChild(sequence8);
			Condition_bt_BOSS_BOSS20_DestinationSelect_node24 condition_bt_BOSS_BOSS20_DestinationSelect_node8 = new Condition_bt_BOSS_BOSS20_DestinationSelect_node24();
			condition_bt_BOSS_BOSS20_DestinationSelect_node8.SetClassNameString("Condition");
			condition_bt_BOSS_BOSS20_DestinationSelect_node8.SetId(24);
			sequence8.AddChild(condition_bt_BOSS_BOSS20_DestinationSelect_node8);
			sequence8.SetHasEvents(sequence8.HasEvents() | condition_bt_BOSS_BOSS20_DestinationSelect_node8.HasEvents());
			Action_bt_BOSS_BOSS20_DestinationSelect_node25 action_bt_BOSS_BOSS20_DestinationSelect_node6 = new Action_bt_BOSS_BOSS20_DestinationSelect_node25();
			action_bt_BOSS_BOSS20_DestinationSelect_node6.SetClassNameString("Action");
			action_bt_BOSS_BOSS20_DestinationSelect_node6.SetId(25);
			sequence8.AddChild(action_bt_BOSS_BOSS20_DestinationSelect_node6);
			sequence8.SetHasEvents(sequence8.HasEvents() | action_bt_BOSS_BOSS20_DestinationSelect_node6.HasEvents());
			selector4.SetHasEvents(selector4.HasEvents() | sequence8.HasEvents());
			Sequence sequence9 = new Sequence();
			sequence9.SetClassNameString("Sequence");
			sequence9.SetId(26);
			selector4.AddChild(sequence9);
			Action_bt_BOSS_BOSS20_DestinationSelect_node28 action_bt_BOSS_BOSS20_DestinationSelect_node7 = new Action_bt_BOSS_BOSS20_DestinationSelect_node28();
			action_bt_BOSS_BOSS20_DestinationSelect_node7.SetClassNameString("Action");
			action_bt_BOSS_BOSS20_DestinationSelect_node7.SetId(28);
			sequence9.AddChild(action_bt_BOSS_BOSS20_DestinationSelect_node7);
			sequence9.SetHasEvents(sequence9.HasEvents() | action_bt_BOSS_BOSS20_DestinationSelect_node7.HasEvents());
			selector4.SetHasEvents(selector4.HasEvents() | sequence9.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | selector4.HasEvents());
			sequence2.SetHasEvents(sequence2.HasEvents() | selector2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence10 = new Sequence();
			sequence10.SetClassNameString("Sequence");
			sequence10.SetId(27);
			selector.AddChild(sequence10);
			Action_bt_BOSS_BOSS20_DestinationSelect_node29 action_bt_BOSS_BOSS20_DestinationSelect_node8 = new Action_bt_BOSS_BOSS20_DestinationSelect_node29();
			action_bt_BOSS_BOSS20_DestinationSelect_node8.SetClassNameString("Action");
			action_bt_BOSS_BOSS20_DestinationSelect_node8.SetId(29);
			sequence10.AddChild(action_bt_BOSS_BOSS20_DestinationSelect_node8);
			sequence10.SetHasEvents(sequence10.HasEvents() | action_bt_BOSS_BOSS20_DestinationSelect_node8.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence10.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
