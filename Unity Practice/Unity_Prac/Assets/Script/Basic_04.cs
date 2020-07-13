using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_04 : MonoBehaviour // MonoBehaviour : 유니티 게임 오브젝트 클래스
/* 9. 상속 관계
 * public class 클래스이름 : 부모클래스
 * 부모클래스 안에 있는 변수들 및 함수를 사용 가능함.
 * ex)
 * 부모클래스 : A, 자식클래스 : B 라고 가정
 * B example = new B();
 * 이 상태에서 A안에 있는 함수나 변수를 사용 할 수 있다.
 * example.변수 또는 함수; 로 사용 가능
 */
{
    // 전역 변수 : 함수 바깥에 선언된 함수
    // 모든 함수에서 선언된 변수 사용 가능
    void Start()
    {
        // 지역 변수 : 함수 안에서 선언된 변수
        // 이 함수 안에서만 선언된 변수 사용가능

        // Debug.Log() : 콘솔창에 메세지 출력
        Debug.Log("Hello Unity");

        // 1. 변수 : 데이터를 메모리에 저장하는 장소
        int level = 5; // 정수형 데이터
        float strength = 15.5f; // 숫자(소수포함)형 데이터 - 뒤에f를 꼭 붙이자 
        string playerName = "나검사"; // 문자열 데이터
        bool isFullLevel = false; // 논리형 데이터

        // 프로그래밍 순서는 선언-> 초기화 -> 호출(사용) 순서!
        /* Debug.Log("용사의 이름은?");
        Debug.Log(playerName);
        Debug.Log("용사의 레벨은?");
        Debug.Log(level);
        Debug.Log("용사의 힘은?");
        Debug.Log(strength);
        Debug.Log("용사는 만렙인가?");
        Debug.Log(isFullLevel); */

        // 2. 그룹형 변수 : 변수들을 묶은 하나의 장소
        // ↓배열 : 가장 기본적인 고정형 그룹형 변수
        string[] monsters = { "슬라임", "사막뱀", "악마" };
        /* Debug.Log("맵에 존재하는 몬스터");
        Debug.Log(monsters[0]); // 프로그래밍의 시작은 0!
        Debug.Log(monsters[1]);
        Debug.Log(monsters[2]); */

        int[] monsterLevel = new int[3]; // 이런식으로 배열의 크기 선언 가능
        monsterLevel[0] = 1;
        monsterLevel[1] = 6;
        monsterLevel[2] = 20;
        /*Debug.Log("맵에 존재하는 몬스터 레벨");
        Debug.Log(monstersLevel[0]); 
        Debug.Log(monstersLevel[1]);
        Debug.Log(monstersLevel[2]); */

        // List : 기능이 추가된 가변형 그룹형 변수
        List<string> items = new List<string>();
        items.Add("생명물약30"); // List에 추가하는 법 - .Add
        items.Add("마나물약30");

        items.RemoveAt(0); // list 1번째 요소 삭제 - RemoveAt
        /*Debug.Log(items[0]); 
        Debug.Log(items[1]); // 크기를 벗어난 탐색이므로 오류 발생! */

        // 3. 연산자 : 상수, 변수값을 연산해주는 기호
        int exp = 1500;
        exp = 1500 + 320; // 덧셈
        exp = exp - 10; // 뺄셈
        level = exp / 300; // 나눗셈
        strength = level * 3.1f; // 곱셈

        int nextExp = 300 - (exp % 300); // % : 몫이 아닌 나머지를 출력

        // 문자열
        string title = "전설의";
        // Debug.Log(title + " " + playerName); // 문장도 이런식으로 붙이기 가능]

        // boolean 논리 연산자
        int fullLevel = 99;
        isFullLevel = level == fullLevel; // 서로 같음을 비교할때는 ==을 써주면 된다.
        // > 초과  < 미만  >= 이상  <= 이하 == 같음
        bool isEndTutorial = level > 10;
        /*
        int health = 30;
        int mana = 25;
        bool isBadCondition = health <= 50 && mana <= 20; // && - and연산자
        bool isBadCondition = health <= 50 || mana <= 20; // || - or연산자

        // 3항 연산자 [Irada ? A : B ] : Irada가 True일때 A, False일때 B
        string condition = isBadCondition ? "나쁨" : "좋음"; */


        // 4. 키워드 : 프로그래밍 언어를 구성하는 특별한 언어
        // int float 등 키워드들은 변수 이름 또는 값으로 사용할 수 없다!
        // ex) int float = 1; string name = List;

        // 5. 조건문 : 조건에 만족하면 로직을 실행하는 제어문
        // if문과 switch문이 있다.
        /* ex) if문
         * if(){}
         * else if(){}
         * else{}
         * 
         * switch(){
         *  case A:
         *      ~~~
         *      break;
         *      case A:
         *      ~~~
         *      break;
         *  case B:
         *      ~~~
         *      break;
         *  default:  // <- case에서 값이없을경우
         *      break;
         */

        // 6. 반복문
        /* while : 조건이 true일때, 로직 반복 실행
         * ex)
         * while(조건){
         *      로직
         * }
         */

        /* for : 변수를 연산하면서 로직 반복 실행
         * ex)
         * for(연산될 변수(이 안에서 변수 선언 가능) ; 반복할 조건 ; 연산){
         *      로직
         * }
         *
         * 그룹형 변수 길이 : 
         * 배열이름.Length    리스트이름.Count
         * 
         * foreach : for의 그룹형 변수 탐색 특화
         * ex)
         * foreach(키워드 변수 in 그룹){
         *      로직
         * }
         */
    }

    // 7. 함수(메소드) : 기능을 편리하게 사용하도록 구성된 영역
    /* ex)
     * 반환변수(int등) 함수이름(받는 변수(int등)){
     *      로직
     *      반환하는 변수가 있을시에
     *      return 꼭 필요
     *      없을시 반환변수는 void
     * }
     */

    // 8. 클래스 : 하나의 사물(오브젝트)와 대응하는 로직
    /* class : 클래스 선언에 사용
     * 
     * 인스턴스 : 정의된 클래스를 변수 초기화로 실체화
     * ex)
     * 클래스이름 변수 = new 클래스이름();
     * 변수.함수 -> 타클래스의 함수 및 변수를 사용가능
     * 그럴경우 불러오는 클래스의 변수들은 앞에 public를 붙여줘야됨
     * private : 외부 클래스에 비공개로 설정하는 접근자 <- 변수앞에 public을 붙이지 않으면 기본적으로 다 private상태임
     * public : 외부 클래스에 공개로 설정하는 접근자
     */ 
}
