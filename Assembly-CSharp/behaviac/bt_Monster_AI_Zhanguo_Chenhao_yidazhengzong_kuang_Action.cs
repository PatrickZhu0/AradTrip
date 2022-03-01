using System;

namespace behaviac
{
	// Token: 0x02003EE6 RID: 16102
	public static class bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action
	{
		// Token: 0x06016547 RID: 91463 RVA: 0x006C179C File Offset: 0x006BFB9C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Zhanguo/Chenhao_yidazhengzong_kuang_Action");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node22 condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node = new Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node22();
			condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node.SetId(22);
			sequence.AddChild(condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node.HasEvents());
			Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node23 condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node2 = new Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node23();
			condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node2.SetId(23);
			sequence.AddChild(condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node2.HasEvents());
			Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node25 condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node3 = new Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node25();
			condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node3.SetId(25);
			sequence.AddChild(condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node3.HasEvents());
			Action_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node26 action_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node = new Action_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node26();
			action_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node.SetId(26);
			sequence.AddChild(action_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
