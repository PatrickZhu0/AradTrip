using System;

namespace behaviac
{
	// Token: 0x020023DA RID: 9178
	public static class bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event
	{
		// Token: 0x06013119 RID: 78105 RVA: 0x005A71B0 File Offset: 0x005A55B0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("AutoFight/AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(12);
			bt.AddChild(sequence);
			Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node9 action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node = new Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node9();
			action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node.SetId(9);
			sequence.AddChild(action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node.HasEvents());
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			sequence.AddChild(selector);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(5);
			selector.AddChild(sequence2);
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node7 condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node7();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node.SetId(7);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node10 condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node10();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2.SetId(10);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node6 condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node6();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3.SetId(6);
			sequence2.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node8 action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2 = new Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node8();
			action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2.SetId(8);
			sequence2.AddChild(action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(4);
			selector.AddChild(sequence3);
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node1 condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node4 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node1();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node4.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node4.SetId(1);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node4.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2 condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node5 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node5.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node5.SetId(2);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node5.HasEvents());
			Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node11 condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node6 = new Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node11();
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node6.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node6.SetId(11);
			sequence3.AddChild(condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node6.HasEvents());
			Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3 action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3 = new Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3();
			action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3.SetId(3);
			sequence3.AddChild(action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selector.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
