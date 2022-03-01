using System;

namespace behaviac
{
	// Token: 0x020040CA RID: 16586
	public static class bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong
	{
		// Token: 0x060168EB RID: 92395 RVA: 0x006D4AD4 File Offset: 0x006D2ED4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/zhaohuanshi1/zhaohuanshi_Zhaohuan_tongyong");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(1);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(3);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node4 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node4();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node5 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node2 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node5();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node2.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node2.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node7 action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node = new Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node7();
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node.SetId(7);
			sequence.AddChild(action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node6 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node3 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node6();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node3.SetId(6);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node3.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node8 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node4 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node8();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node4.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node4.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node9 action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node2 = new Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node9();
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node2.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node2.SetId(9);
			sequence2.AddChild(action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
