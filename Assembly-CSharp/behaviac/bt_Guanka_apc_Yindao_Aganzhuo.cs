using System;

namespace behaviac
{
	// Token: 0x02002AD6 RID: 10966
	public static class bt_Guanka_apc_Yindao_Aganzhuo
	{
		// Token: 0x06013EC6 RID: 81606 RVA: 0x005FAC44 File Offset: 0x005F9044
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Guanka_apc/Yindao_Aganzhuo");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Guanka_apc_Yindao_Aganzhuo_node2 condition_bt_Guanka_apc_Yindao_Aganzhuo_node = new Condition_bt_Guanka_apc_Yindao_Aganzhuo_node2();
			condition_bt_Guanka_apc_Yindao_Aganzhuo_node.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Yindao_Aganzhuo_node.SetId(2);
			sequence.AddChild(condition_bt_Guanka_apc_Yindao_Aganzhuo_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Guanka_apc_Yindao_Aganzhuo_node.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(3);
			sequence.AddChild(sequence2);
			Condition_bt_Guanka_apc_Yindao_Aganzhuo_node4 condition_bt_Guanka_apc_Yindao_Aganzhuo_node2 = new Condition_bt_Guanka_apc_Yindao_Aganzhuo_node4();
			condition_bt_Guanka_apc_Yindao_Aganzhuo_node2.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Yindao_Aganzhuo_node2.SetId(4);
			sequence2.AddChild(condition_bt_Guanka_apc_Yindao_Aganzhuo_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Guanka_apc_Yindao_Aganzhuo_node2.HasEvents());
			Action_bt_Guanka_apc_Yindao_Aganzhuo_node5 action_bt_Guanka_apc_Yindao_Aganzhuo_node = new Action_bt_Guanka_apc_Yindao_Aganzhuo_node5();
			action_bt_Guanka_apc_Yindao_Aganzhuo_node.SetClassNameString("Action");
			action_bt_Guanka_apc_Yindao_Aganzhuo_node.SetId(5);
			sequence2.AddChild(action_bt_Guanka_apc_Yindao_Aganzhuo_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Guanka_apc_Yindao_Aganzhuo_node.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
