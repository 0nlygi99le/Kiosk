# Kiosk (WinForms, C#)

WinForms로 구현한 키오스크 데스크톱 앱입니다.  
동적 UI 생성(ProductList → ProductCard), 이벤트 중계, 모델 분리(Product)를 통해  
화면 구성(배치/컨트롤)이 바뀌어도 
핵심 기능(장바구니·결제·주문) 로직은 독립적으로 확장되도록 설계했습니다.


## 핵심 기능
- Product 기반 상품 카드(ProductCard) 동적 생성 및 표시
- 카드 클릭 → 대표 이벤트(ItemClicked)로 외부에 상품 데이터 전달
- Product(모델) / ProductCard(UI) 분리로 결합도 감소
- (예정) 주문내역/ 결제


## 실행 방법
1. Visual Studio에서 `KioskByGT.sln` 열기
2. 실행(CTRL+F5)

## 폴더 구조
- `Models/` : Product 등 데이터 모델
- `Components/` : UserControl(ProductCard, ProductList 등)
- `Utils/` : 공용 유틸(있다면)

## 기술 스택
- C# / WinForms
