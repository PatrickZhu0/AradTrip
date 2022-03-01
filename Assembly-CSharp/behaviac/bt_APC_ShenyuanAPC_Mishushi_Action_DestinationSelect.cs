using System;

namespace behaviac
{
	// Token: 0x02001EAA RID: 7850
	public static class bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect
	{
		// Token: 0x060126FD RID: 75517 RVA: 0x005645C0 File Offset: 0x005629C0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("APC/ShenyuanAPC_Mishushi_Action_DestinationSelect");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2 condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node = new Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2();
			condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node.SetClassNameString("Condition");
			condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node.SetId(2);
			sequence.AddChild(condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node.HasEvents());
			Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3 action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node = new Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3();
			action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node.SetClassNameString("Action");
			action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node.SetId(3);
			sequence.AddChild(action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(13);
			selector.AddChild(sequence2);
			Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node14 condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2 = new Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node14();
			condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2.SetClassNameString("Condition");
			condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2.SetId(14);
			sequence2.AddChild(condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2.HasEvents());
			Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node12 condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3 = new Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node12();
			condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3.SetClassNameString("Condition");
			condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3.SetId(12);
			sequence2.AddChild(condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3.HasEvents());
			Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node15 action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2 = new Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node15();
			action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2.SetClassNameString("Action");
			action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2.SetId(15);
			sequence2.AddChild(action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(8);
			selector.AddChild(sequence3);
			Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node9 condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node4 = new Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node9();
			condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node4.SetClassNameString("Condition");
			condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node4.SetId(9);
			sequence3.AddChild(condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node4.HasEvents());
			Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node10 action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3 = new Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node10();
			action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3.SetClassNameString("Action");
			action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3.SetId(10);
			sequence3.AddChild(action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(4);
			selector.AddChild(sequence4);
			Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node5 condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node5 = new Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node5();
			condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node5.SetClassNameString("Condition");
			condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node5.SetId(5);
			sequence4.AddChild(condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node5);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node5.HasEvents());
			Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node16 action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node4 = new Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node16();
			action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node4.SetClassNameString("Action");
			action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node4.SetId(16);
			sequence4.AddChild(action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
