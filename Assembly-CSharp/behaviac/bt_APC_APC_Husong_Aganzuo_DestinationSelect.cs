using System;

namespace behaviac
{
	// Token: 0x02001D60 RID: 7520
	public static class bt_APC_APC_Husong_Aganzuo_DestinationSelect
	{
		// Token: 0x0601247E RID: 74878 RVA: 0x00555684 File Offset: 0x00553A84
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("APC/APC_Husong_Aganzuo_DestinationSelect");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node2 condition_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node = new Condition_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node2();
			condition_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node.SetId(2);
			sequence.AddChild(condition_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node.HasEvents());
			Action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node3 action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node = new Action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node3();
			action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node.SetClassNameString("Action");
			action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node.SetId(3);
			sequence.AddChild(action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(4);
			selector.AddChild(sequence2);
			Action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node5 action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node2 = new Action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node5();
			action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node2.SetClassNameString("Action");
			action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node2.SetId(5);
			sequence2.AddChild(action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
