using System;

namespace behaviac
{
	// Token: 0x0200248E RID: 9358
	public static class bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun
	{
		// Token: 0x06013269 RID: 78441 RVA: 0x005AEF04 File Offset: 0x005AD304
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("AutoFight/AutoFight_Fight_veryhard_Move_Jianhun");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(20);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(18);
			selector.AddChild(sequence);
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node19 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node19();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node.SetId(19);
			sequence.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node21 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node21();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2.SetId(21);
			sequence.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3.SetId(2);
			sequence.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node22 action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node = new Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node22();
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node.SetId(22);
			sequence.AddChild(action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(4);
			selector.AddChild(sequence2);
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node6 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node4 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node6();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node4.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node4.SetId(6);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node4.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node8 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node5 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node8();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node5.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node5.SetId(8);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node5.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node1 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node6 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node1();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node6.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node6.SetId(1);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node6.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node10 action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2 = new Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node10();
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2.SetId(10);
			sequence2.AddChild(action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(0);
			selector.AddChild(sequence3);
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node7 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node7.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node7.SetId(3);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node7.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node5 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node8 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node5();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node8.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node8.SetId(5);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node8.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node7 condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node9 = new Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node7();
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node9.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node9.SetId(7);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node9.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node9 action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3 = new Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node9();
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3.SetId(9);
			sequence3.AddChild(action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
