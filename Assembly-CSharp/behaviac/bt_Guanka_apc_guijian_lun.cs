using System;

namespace behaviac
{
	// Token: 0x02002A6A RID: 10858
	public static class bt_Guanka_apc_guijian_lun
	{
		// Token: 0x06013DFC RID: 81404 RVA: 0x005F512C File Offset: 0x005F352C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Guanka_apc/guijian_lun");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Guanka_apc_guijian_lun_node2 condition_bt_Guanka_apc_guijian_lun_node = new Condition_bt_Guanka_apc_guijian_lun_node2();
			condition_bt_Guanka_apc_guijian_lun_node.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_lun_node.SetId(2);
			sequence.AddChild(condition_bt_Guanka_apc_guijian_lun_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Guanka_apc_guijian_lun_node.HasEvents());
			DecoratorAlwaysSuccess_bt_Guanka_apc_guijian_lun_node3 decoratorAlwaysSuccess_bt_Guanka_apc_guijian_lun_node = new DecoratorAlwaysSuccess_bt_Guanka_apc_guijian_lun_node3();
			decoratorAlwaysSuccess_bt_Guanka_apc_guijian_lun_node.SetClassNameString("DecoratorAlwaysSuccess");
			decoratorAlwaysSuccess_bt_Guanka_apc_guijian_lun_node.SetId(3);
			sequence.AddChild(decoratorAlwaysSuccess_bt_Guanka_apc_guijian_lun_node);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(4);
			decoratorAlwaysSuccess_bt_Guanka_apc_guijian_lun_node.AddChild(sequence2);
			Condition_bt_Guanka_apc_guijian_lun_node5 condition_bt_Guanka_apc_guijian_lun_node2 = new Condition_bt_Guanka_apc_guijian_lun_node5();
			condition_bt_Guanka_apc_guijian_lun_node2.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_lun_node2.SetId(5);
			sequence2.AddChild(condition_bt_Guanka_apc_guijian_lun_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Guanka_apc_guijian_lun_node2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(6);
			sequence2.AddChild(sequence3);
			Condition_bt_Guanka_apc_guijian_lun_node7 condition_bt_Guanka_apc_guijian_lun_node3 = new Condition_bt_Guanka_apc_guijian_lun_node7();
			condition_bt_Guanka_apc_guijian_lun_node3.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_lun_node3.SetId(7);
			sequence3.AddChild(condition_bt_Guanka_apc_guijian_lun_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Guanka_apc_guijian_lun_node3.HasEvents());
			Condition_bt_Guanka_apc_guijian_lun_node15 condition_bt_Guanka_apc_guijian_lun_node4 = new Condition_bt_Guanka_apc_guijian_lun_node15();
			condition_bt_Guanka_apc_guijian_lun_node4.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_lun_node4.SetId(15);
			sequence3.AddChild(condition_bt_Guanka_apc_guijian_lun_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Guanka_apc_guijian_lun_node4.HasEvents());
			Action_bt_Guanka_apc_guijian_lun_node21 action_bt_Guanka_apc_guijian_lun_node = new Action_bt_Guanka_apc_guijian_lun_node21();
			action_bt_Guanka_apc_guijian_lun_node.SetClassNameString("Action");
			action_bt_Guanka_apc_guijian_lun_node.SetId(21);
			sequence3.AddChild(action_bt_Guanka_apc_guijian_lun_node);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Guanka_apc_guijian_lun_node.HasEvents());
			sequence2.SetHasEvents(sequence2.HasEvents() | sequence3.HasEvents());
			decoratorAlwaysSuccess_bt_Guanka_apc_guijian_lun_node.SetHasEvents(decoratorAlwaysSuccess_bt_Guanka_apc_guijian_lun_node.HasEvents() | sequence2.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | decoratorAlwaysSuccess_bt_Guanka_apc_guijian_lun_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
