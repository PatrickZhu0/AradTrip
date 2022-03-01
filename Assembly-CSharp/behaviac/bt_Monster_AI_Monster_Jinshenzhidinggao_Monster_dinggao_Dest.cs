using System;

namespace behaviac
{
	// Token: 0x02003699 RID: 13977
	public static class bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect
	{
		// Token: 0x0601554F RID: 87375 RVA: 0x0066F33C File Offset: 0x0066D73C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Jinshenzhidinggao/Monster_dinggao_DestinationSelect");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(4);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(5);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node6 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node6();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node.HasEvents());
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node9 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node9();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2.SetId(9);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2.HasEvents());
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node7 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node3 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node7();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node3.SetId(7);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node3.HasEvents());
			Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node8 action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node = new Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node8();
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(0);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node1 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node4 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node1();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node4.SetId(1);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node4.HasEvents());
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node5 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node5.SetId(2);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node5.HasEvents());
			Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node3 action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2 = new Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node3();
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2.SetId(3);
			sequence2.AddChild(action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
