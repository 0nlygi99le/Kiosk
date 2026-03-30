# Kiosk (WinForms, C#)

WinForms로 구현한 키오스크 데스크톱 애플리케이션
단순한 화면 구현에 그치지 않고
동적 UI 생성, 대표 이벤트 중계, 데이터 모델 분리를 중심으로 설계

특히 ProductList → ProductCard 구조를 통해 상품 카드를 동적으로 설계하고,
클릭 결과를 Product 데이터로 정제하여 외부로 전달하며,
장바구니 영역은 PickList / PickItem 구조로 분리해 상태를 독립적으로 관리할 수 있도록 구성

이를 통해 화면 배치나 컨트롤 구성이 변경되더라도,  
핵심 로직(상품 선택, 장바구니 상태 관리, 이후 확장될 결제/주문 흐름)은 
비교적 독립적으로 유지·확장할 수 있도록 설계

## 핵심 목표
1. 상품 카드의 동적 생성
   - Product 데이터를 기반으로 ProductCard를 동적으로 생성
   - 상품 목록 변경 시 UI를 다시 렌더링할 수 있는 구조 설계

2. **카드 내부 클릭을 하나의 이벤트로 통합**
   - 카드 내부 자식 컨트롤들의 Click 이벤트를 재귀적으로 구독
   - 카드 내부 어디를 눌러도 ProductCard.Clicked 하나로 처리되도록 구성

3. 장바구니 상태 흐름 분리
   - 동일 상품 재선택 시 중복 UI가 생기지 않도록 설계
   - ID를 기준으로 중복 여부를 판별하고,  
     같은 상품이면 Count++, 없으면 new PickItem으로 흐름 분리

4. UI와 데이터의 역할 분리
   - Product는 순수 데이터 모델
   - ProductCard, PickItem은 UI 표현과 상태 반영 담당
   - 외부에는 UI 컨트롤이 아닌 데이터 중심으로 전달되도록 구성

## 핵심 기능
- Product 기반 상품 카드(ProductCard) 동적 생성 및 표시
- 카드 클릭 → 대표 이벤트(ItemClicked)로 외부에 상품 데이터 전달
- Product(모델) / ProductCard(UI) 분리로 결합도 감소
- 동일 상품 재선택 시 수량 증가 처리
- PickItem 수량 변경 시 합계 가격 UI 반영
- 삭제 및 수량 변화 결과를 대표 이벤트로 외부 전달 가능

## 구조 요약
1. ProductList
 - Items : ObservableCollection<Product>를 기반으로 상품 목록 관리
 - ProductCard를 동적으로 생성하고 클릭 이벤트를 내부에서 구독
 - 클릭 결과를 `Product`로 정제하여 ItemClicked로 외부 전달

- Form
  - ProductList와 PickList를 연결하는 브리지 역할 수행
  - 선택된 Product를 pickList.AddItem(product)로 전달

- PickList
  - List<PickItem>기반으로 장바구니 상태 관리
  - 동일 상품이면 수량 증가, 새 상품이면 PickItem 생성
  - ItemValueChanged를 통해 현재 장바구니 상태를 외부 전달

즉, 초반는 상품 선택 전달 구조, 
후반은 장바구니 상태 관리 구조로 역할 분리

## 향후 예정 계획
1. 결제 버튼 설계
- 현재 장바구니 상태를 기반으로 결제 흐름 연결
- 총 가격 계산, 주문 확정, 주문 완료 상태 처리

2. DB 연동
- 상품 데이터를 DB에서 조회하여 ProductList.Items에 공급
- 주문 완료 시 장바구니 상태를 주문 데이터로 저장

3. 센서 확장
- 사용자 접근 감지 시 대기 화면 → 주문 화면 자동 전환
- 사용자 이탈 시 초기 화면 복귀

## 실행 방법
1. Visual Studio에서 `KioskByGT.sln` 열기
2. 실행(CTRL+F5)

## 폴더 구조
- Models/: Product 등 데이터 모델
- Components/: UserControl(ProductCard, ProductList, PickItem, PickList 등)
- Utils/: 공용 유틸

## 기술 스택
- Language: C#
- UI Framework: WinForms
- Tool: Visual Studio, Git, GitHub
- Planned Extension: DB 연동, 센서 기반 사용자 접근 감지
