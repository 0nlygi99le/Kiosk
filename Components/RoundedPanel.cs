using KioskByGT.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace KioskByGT.Components
{
    /// <summary>
    /// RoundedPanel (Custom Control)
    /// - Panel을 상속해 "둥근 모서리 + 테두리"를 OnPaint에서 직접 구현(렌더링)
    /// - 키오스크 카드형 UI(메뉴/장바구니...) 재사용 목적
    /// </summary>
    public class RoundedPanel : Panel   
    {
        // Custom properties state (기본 Panel에 없는 속성이라 내부 필드로 보관)
        private int _borderWidth = 2;   //테두리 두께
        private int _borderRadius = 8;   //테두리 휜 정도
        private Color _borderColor = Color.Black;
        private Color _innerBackgroundColor = Color.White;

        /// <summary>
        /// [모양 깨짐(잔상/클리핑/라운드 모서리 어긋남) 방지]
        /// - 컨트롤의 크기가 바뀌는 순간(Resize)에 다시 그리기(Invalidate)를 요청함
        /// - Invalidate()는 "이 영역은 다시 그려야 함"을 표시하고, 이후 OnPaint 호출을 유도함
        /// - 필수는 아니지만, 커스텀 페인팅(라운드 모서리 등)을 하는 컨트롤은
        ///   Resize 시점마다 재그림을 보장하는 편이 안정적
        public RoundedPanel()
        {
            // 컨트롤의 가로/세로 크기가 변경될 때마다 발생하는 이벤트
            // → 크기 변경 시점에 다시 그리기를 요청하여 모양 깨짐을 예방
            Resize += RoundedPanel_Resize;
        }

        /// <summary>
        /// Resize 이벤트 핸들러
        /// - 크기 변경 직후, 이전에 그린 결과는 현재 크기와 맞지 않을 수 있으므로 무효화(Invalidate)
        /// - 결과적으로 OnPaint가 다시 호출되어 새 크기에 맞춰 라운드 모서리를 재계산/재그림
        /// </summary>
        private void RoundedPanel_Resize(object? sender, EventArgs e)
        {
            // "크기가 바뀌었으니 다시 그려라"라고 요청 -> 이후 OnPaint 호출 유도
            Invalidate();
        }

        // DefaultValue: 커스텀 속성의 기본값을 명시(초기화) + 속성창에서 Reset 기준을 제공
        [DefaultValue(2)]
        [Category("Custom RoundedPanel"), Description("테두리 두께: 값이 클수록 테두리가 두꺼워짐.")]
        public int BorderWidth
        {
			get { return _borderWidth; }
			set { _borderWidth = value; 
                Invalidate();  // '다시 그려라는 예약': 여기서는 디자이너 화면에 변경사항이 즉시 반영되도록 함.
            }
		}

        [DefaultValue(8)]
        [Category("Custom RoundedPanel"), Description("모서리 둥근 정도: 값이 클수록 더 둥글어짐.")]
        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color),"Black")]
        [Category("Custom RoundedPanel"), Description("테두리 색상.")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "White")]
        [Category("Custom RoundedPanel"), Description("패널 내부(배경) 색상.")]
        public Color InnerBackgroundColorVar
        {
            get { return _innerBackgroundColor; }
            set { _innerBackgroundColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// [OnPaint 오버라이드 - 테두리 그리기] 
        /// - 기본 Panel은 "사각형 배경" 수준은 처리하지만 
        /// "둥근 모서리 + 테두리" 표현은 기본 제공이 아니므로,
        ///  원하는 스타일을 위해 OnPaint를 오버라이드해 직접 그림.
        /// - 흐름: rect(안전한 경계선) → path(설계도) → Fill(배경) → Draw(테두리)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // 1. Panel의 기본 그리기 처리 후, 커스텀한 그리기를 덮어씌움

            // 2. 임의 CreateGraphics()는 다음 Paint에서 사라지는 문제가 생길 수 있음
            // 때문에 e.Graphic( WinForms가 제공하는 올바른 대상(현재 컨트롤 표면))을 받아와 사용
            Graphics graphics = e.Graphics; 
            graphics.SmoothingMode =SmoothingMode.HighQuality;   //3. 곡선(라운드) 계단 현상 완화

            //4. 패널 경계 계산 (테두리 두께를 감안한 "순수 내부 사각형 영역(rect)")
            Rectangle rect = new Rectangle(_borderWidth, _borderWidth, Width - _borderWidth * 2, Height - _borderWidth * 2);

            // graphics.DrawRectangle(new Pen(_borederColor, _borederWidth), rect);  -> 잘 그려지나 확인 코드

            //5. 라운드 사각형 설계도(path): rect(영역) + radius(휘어진 정도)로 모양 결정
            GraphicsPath path =  GraphicsUtil.GetRoundedRectanglePath(rect, _borderRadius);

            // IDisposable → using으로 즉시 Dispose(누수 방지)
            // 6. 내부 채우기(Fill) - "배경(내부)"를 만듬
            using (SolidBrush innerBrush = new SolidBrush(_innerBackgroundColor))
            {
                graphics.FillPath(innerBrush, path);    
            }

            //7. 외곽선 그리기(Draw) - "테두리"를 만듬
            using (Pen borderPen = new Pen(_borderColor, _borderWidth)) 
            { 
                graphics.DrawPath(borderPen, path); 
              
            }
        }
    }
}























