#pragma region Include
#include <stm32f4xx_hal.h>
#include <stdint-gcc.h>
#include <stm32f4xx_hal_gpio.h>

#ifdef __cplusplus
#include "stm32f4xx_hal_conf.h"

extern "C"
#endif
#pragma endregion 

#pragma region Define
#define RED_LED GPIO_PIN_14
#define ORANGE_LED GPIO_PIN_13
#define GREEN_LED GPIO_PIN_12
#define BLUE_LED GPIO_PIN_15
#define USER_BUTTON GPIO_PIN_0
#pragma endregion 

#pragma region Prototype
void Initialize_Led();
void Initialize_Button();
#pragma endregion 

#pragma region Member Functions

void SysTick_Handler(void)
{
	HAL_IncTick();
	HAL_SYSTICK_IRQHandler();
}

void Initialize_Led()
{
	GPIO_InitTypeDef GPIO_InitStructure;
	GPIO_InitStructure.Pin = GREEN_LED | RED_LED | ORANGE_LED | BLUE_LED;
	GPIO_InitStructure.Mode = GPIO_MODE_OUTPUT_PP;
	GPIO_InitStructure.Speed = GPIO_SPEED_HIGH;
	GPIO_InitStructure.Pull = GPIO_NOPULL;
	HAL_GPIO_Init(GPIOD, &GPIO_InitStructure);
}

void Initialize_Button()
{
	GPIO_InitTypeDef GPIO_InitStructure;
	GPIO_InitStructure.Pin = USER_BUTTON;
	GPIO_InitStructure.Mode = GPIO_MODE_IT_RISING;
	GPIO_InitStructure.Speed = GPIO_SPEED_HIGH;
	GPIO_InitStructure.Pull = GPIO_PULLDOWN;
	HAL_GPIO_Init(GPIOA, &GPIO_InitStructure);
	
}

#pragma endregion 



int main(void)
{
	HAL_Init();

	__GPIOD_CLK_ENABLE();

	Initialize_Led();

	for (;;)
	{
		HAL_GPIO_TogglePin(GPIOD, GREEN_LED);
		HAL_Delay(1000);
		HAL_GPIO_TogglePin(GPIOD, GREEN_LED);
		HAL_Delay(1000);
	}
}
