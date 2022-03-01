using System;

namespace behaviac
{
	// Token: 0x02004035 RID: 16437
	public static class bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect
	{
		// Token: 0x060167CA RID: 92106 RVA: 0x006CE624 File Offset: 0x006CCA24
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/zhaohuanshi1/zhaohuanshi_Bingnaisi_DestinationSelect");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Selector selector2 = new Selector();
			selector2.SetClassNameString("Selector");
			selector2.SetId(1);
			selector.AddChild(selector2);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(2);
			selector2.AddChild(sequence);
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node4 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node4();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node5 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node2 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node5();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node2.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node2.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node6 action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node = new Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node6();
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(3);
			selector2.AddChild(sequence2);
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node7 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node3 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node7();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node3.SetId(7);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node3.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node8 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node4 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node8();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node4.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node4.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node9 action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node2 = new Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node9();
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node2.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node2.SetId(9);
			sequence2.AddChild(action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node2.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | selector2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
