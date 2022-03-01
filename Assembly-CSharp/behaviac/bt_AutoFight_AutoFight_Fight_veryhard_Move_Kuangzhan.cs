using System;

namespace behaviac
{
	// Token: 0x0200249F RID: 9375
	public static class bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan
	{
		// Token: 0x0601328A RID: 78474 RVA: 0x005AF830 File Offset: 0x005ADC30
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("AutoFight/AutoFight_Fight_veryhard_Move_Kuangzhan");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(20);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(18);
			selector.AddChild(sequence);
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node19 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node19();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node.SetId(19);
			sequence.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node21 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node21();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2.SetId(21);
			sequence.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3.SetId(2);
			sequence.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node22 action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node = new Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node22();
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node.SetId(22);
			sequence.AddChild(action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(4);
			selector.AddChild(sequence2);
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node6 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node4 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node6();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node4.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node4.SetId(6);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node4.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node8 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node5 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node8();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node5.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node5.SetId(8);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node5.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node1 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node6 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node1();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node6.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node6.SetId(1);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node6.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node10 action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2 = new Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node10();
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2.SetId(10);
			sequence2.AddChild(action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(11);
			selector.AddChild(sequence3);
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node12 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node7 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node12();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node7.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node7.SetId(12);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node7.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node13 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node8 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node13();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node8.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node8.SetId(13);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node8.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node14 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node9 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node14();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node9.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node9.SetId(14);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node9.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node15 action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3 = new Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node15();
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3.SetId(15);
			sequence3.AddChild(action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(0);
			selector.AddChild(sequence4);
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node10 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node10.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node10.SetId(3);
			sequence4.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node10);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node10.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node5 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node11 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node5();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node11.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node11.SetId(5);
			sequence4.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node11);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node11.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node7 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node12 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node7();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node12.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node12.SetId(7);
			sequence4.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node12);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node12.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node9 action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node4 = new Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node9();
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node4.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node4.SetId(9);
			sequence4.AddChild(action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
