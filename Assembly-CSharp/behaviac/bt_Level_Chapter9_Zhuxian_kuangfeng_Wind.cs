using System;

namespace behaviac
{
	// Token: 0x02002AE4 RID: 10980
	public static class bt_Level_Chapter9_Zhuxian_kuangfeng_Wind
	{
		// Token: 0x06013EE0 RID: 81632 RVA: 0x005FB330 File Offset: 0x005F9730
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Level/Chapter9/Zhuxian_kuangfeng_Wind");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(34);
			bt.AddChild(sequence);
			Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node5 condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node = new Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node5();
			condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node.SetClassNameString("Condition");
			condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node.SetId(5);
			sequence.AddChild(condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node.HasEvents());
			Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node35 action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node = new Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node35();
			action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node.SetClassNameString("Action");
			action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node.SetId(35);
			sequence.AddChild(action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node.HasEvents());
			Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4 action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node2 = new Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4();
			action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node2.SetClassNameString("Action");
			action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node2.SetId(4);
			sequence.AddChild(action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node2.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(42);
			sequence.AddChild(sequence2);
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(15);
			sequence2.AddChild(selector);
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(2);
			selector.AddChild(sequence3);
			Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node6 condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node2 = new Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node6();
			condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node2.SetClassNameString("Condition");
			condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node2.SetId(6);
			sequence3.AddChild(condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node2);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node2.HasEvents());
			Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node8 action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node3 = new Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node8();
			action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node3.SetClassNameString("Action");
			action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node3.SetId(8);
			sequence3.AddChild(action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(9);
			selector.AddChild(sequence4);
			Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node10 condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node3 = new Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node10();
			condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node3.SetClassNameString("Condition");
			condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node3.SetId(10);
			sequence4.AddChild(condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node3);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node3.HasEvents());
			Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node0 action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4 = new Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node0();
			action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4.SetClassNameString("Action");
			action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4.SetId(0);
			sequence4.AddChild(action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(3);
			selector.AddChild(sequence5);
			Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node12 condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4 = new Condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node12();
			condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4.SetClassNameString("Condition");
			condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4.SetId(12);
			sequence5.AddChild(condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4.HasEvents());
			Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node13 action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node5 = new Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node13();
			action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node5.SetClassNameString("Action");
			action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node5.SetId(13);
			sequence5.AddChild(action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			sequence2.SetHasEvents(sequence2.HasEvents() | selector.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
